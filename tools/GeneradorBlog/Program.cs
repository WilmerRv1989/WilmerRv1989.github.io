using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using Markdig;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

// Generador del blog: lee Contenido/Blog/*.md (cabecera YAML + cuerpo Markdown) y produce
//   <salida>/posts.json              índice de entradas publicadas
//   <salida>/articulos/<slug>.html   HTML de cada entrada escrita en Markdown
// Los errores se escriben en formato MSBuild (archivo(línea,columna): error CODIGO: mensaje)
// para que aparezcan en la lista de errores de Visual Studio y detengan el build.

// MSBuild lee la salida como UTF-8 (StdOutEncoding en PortafolioBlog.csproj); sin esto las tildes llegan rotas.
Console.OutputEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

var opciones = Opciones.Leer(args);
if (opciones is null)
{
    Console.WriteLine("Uso: GeneradorBlog --contenido <carpeta> --salida <carpeta> --componentes <carpeta> [--incluir-borradores]");
    return 2;
}

return new Generador(opciones).Ejecutar();

sealed record Opciones(string Contenido, string Salida, string Componentes, bool IncluirBorradores)
{
    public static Opciones? Leer(string[] args)
    {
        string? Valor(string nombre)
        {
            var i = Array.IndexOf(args, nombre);
            return i >= 0 && i + 1 < args.Length ? args[i + 1] : null;
        }

        var contenido = Valor("--contenido");
        var salida = Valor("--salida");
        var componentes = Valor("--componentes");
        if (contenido is null || salida is null || componentes is null) return null;
        return new Opciones(contenido, salida, componentes, args.Contains("--incluir-borradores"));
    }
}

// Campos permitidos en la cabecera. Un campo desconocido (p. ej. una errata) es un error.
sealed class Cabecera
{
    public string? Titulo { get; set; }
    public string? Encabezado { get; set; }
    public string? Resumen { get; set; }
    public string? Fecha { get; set; }
    public string? Categoria { get; set; }
    public List<string> Etiquetas { get; set; } = new();
    public string? Autor { get; set; }
    public bool Borrador { get; set; }
    public string? Componente { get; set; }
}

sealed class Entrada
{
    public required string Slug { get; init; }
    public required string Ruta { get; init; }
    public required Cabecera Cabecera { get; init; }
    public required DateTime Fecha { get; init; }
    public required DateTime MomentoPublicacion { get; init; }
    public required string Cuerpo { get; init; }
    public required int LineaCuerpo { get; init; }
    public bool Programado { get; set; }
    public bool EsComponente => Cabecera.Componente is not null;
}

sealed partial class Generador(Opciones opciones)
{
    private const string AutorPorDefecto = "Wilmer Rodríguez Vega";
    private const string CamposValidos = "titulo, encabezado, resumen, fecha, categoria, etiquetas, autor, borrador, componente";

    // Hora de Costa Rica (UTC-6, sin horario de verano). Una entrada con solo fecha se publica a las 6:00.
    private static readonly TimeSpan DesfaseCostaRica = TimeSpan.FromHours(-6);
    private static readonly TimeSpan HoraPublicacionPorDefecto = TimeSpan.FromHours(6);
    private static readonly string[] FormatosFecha = { "yyyy-MM-dd", "yyyy-MM-dd HH:mm", "yyyy-MM-ddTHH:mm:ss" };

    private readonly MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
    private readonly IDeserializer yaml = new DeserializerBuilder()
        .WithNamingConvention(LowerCaseNamingConvention.Instance)
        .Build();

    private int errores;

    public int Ejecutar()
    {
        if (!Directory.Exists(opciones.Contenido))
        {
            Error(opciones.Contenido, 1, "BLOG000", "No existe la carpeta de contenido del blog.");
            return 1;
        }

        var entradas = Directory.GetFiles(opciones.Contenido, "*.md")
            .OrderBy(ruta => ruta, StringComparer.Ordinal)
            .Select(Leer)
            .OfType<Entrada>()
            .ToList();

        // En Windows "Mi-Entrada.md" y "mi-entrada.md" no pueden convivir, pero en el servidor (Linux) sí.
        foreach (var repetidas in entradas.GroupBy(e => e.Slug, StringComparer.OrdinalIgnoreCase).Where(g => g.Count() > 1))
        {
            foreach (var entrada in repetidas)
                Error(entrada.Ruta, 1, "BLOG010", $"Hay más de una entrada con el nombre '{entrada.Slug}'.");
        }

        var ahoraCostaRica = DateTime.UtcNow + DesfaseCostaRica;
        foreach (var entrada in entradas)
            entrada.Programado = entrada.MomentoPublicacion > ahoraCostaRica;

        var publicables = opciones.IncluirBorradores
            ? entradas
            : entradas.Where(e => !e.Cabecera.Borrador && !e.Programado).ToList();

        ValidarEnlacesInternos(entradas, publicables);

        if (errores > 0)
        {
            Console.WriteLine($"Blog: {errores} error(es) en el contenido. Corrígelos para poder compilar.");
            return 1;
        }

        Escribir(publicables);

        var ocultas = entradas.Count - publicables.Count;
        Console.WriteLine($"Blog: {publicables.Count} entradas generadas" +
            (opciones.IncluirBorradores ? " (incluye borradores y programadas)." : $"; {ocultas} sin publicar (borradores o programadas)."));
        return 0;
    }

    private Entrada? Leer(string ruta)
    {
        var lineas = File.ReadAllLines(ruta);
        var slug = Path.GetFileNameWithoutExtension(ruta);
        var erroresAntes = errores;

        if (!SlugValido().IsMatch(slug))
            Error(ruta, 1, "BLOG001", "El nombre del archivo es la dirección de la entrada: usa solo minúsculas, números, '-' o '_' (sin tildes ni espacios).");

        if (lineas.Length == 0 || lineas[0].Trim() != "---")
        {
            Error(ruta, 1, "BLOG002", "El archivo debe empezar con la cabecera: una línea '---', los campos, y otra línea '---'.");
            return null;
        }

        var cierre = Array.FindIndex(lineas, 1, l => l.Trim() == "---");
        if (cierre < 0)
        {
            Error(ruta, 1, "BLOG002", "La cabecera no está cerrada: falta la segunda línea '---'.");
            return null;
        }

        Cabecera cabecera;
        try
        {
            cabecera = yaml.Deserialize<Cabecera>(string.Join('\n', lineas[1..cierre])) ?? new Cabecera();
        }
        catch (YamlException ex)
        {
            var desconocido = CampoDesconocido().Match(ex.Message);
            var mensaje = desconocido.Success
                ? $"Campo desconocido en la cabecera: '{desconocido.Groups[1].Value.ToLowerInvariant()}'. Campos válidos: {CamposValidos}."
                : $"La cabecera no es válida: {(ex.InnerException ?? ex).Message}";
            Error(ruta, (int)ex.Start.Line + 1, "BLOG003", mensaje);
            return null;
        }

        int LineaDe(string campo)
        {
            var i = Array.FindIndex(lineas, 1, cierre - 1, l => Regex.IsMatch(l, $@"^\s*{campo}\s*:", RegexOptions.IgnoreCase));
            return i >= 0 ? i + 1 : 1;
        }

        void Obligatorio(string? valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                Error(ruta, LineaDe(campo), "BLOG004", $"Falta el campo obligatorio '{campo}'.");
        }

        Obligatorio(cabecera.Titulo, "titulo");
        Obligatorio(cabecera.Resumen, "resumen");
        Obligatorio(cabecera.Categoria, "categoria");
        Obligatorio(cabecera.Fecha, "fecha");

        DateTime fecha = default;
        var tieneHora = false;
        if (!string.IsNullOrWhiteSpace(cabecera.Fecha))
        {
            if (DateTime.TryParseExact(cabecera.Fecha.Trim(), FormatosFecha, null, System.Globalization.DateTimeStyles.None, out fecha))
                tieneHora = cabecera.Fecha.Trim().Length > 10;
            else
                Error(ruta, LineaDe("fecha"), "BLOG005", $"Fecha no válida: '{cabecera.Fecha}'. Usa el formato 2026-10-05, o 2026-10-05 14:30 si quieres indicar la hora.");
        }

        var lineaCuerpo = cierre + 2;
        var cuerpo = string.Join('\n', lineas[(cierre + 1)..]);

        if (cabecera.Componente is not null)
        {
            if (!File.Exists(Path.Combine(opciones.Componentes, cabecera.Componente + ".razor")))
                Error(ruta, LineaDe("componente"), "BLOG006", $"No existe el componente '{cabecera.Componente}' (se buscó {cabecera.Componente}.razor en {opciones.Componentes}).");
            if (!string.IsNullOrWhiteSpace(cuerpo))
                Error(ruta, lineaCuerpo, "BLOG007", "Una entrada con 'componente' no lleva cuerpo: su contenido está en el componente.");
        }
        else if (string.IsNullOrWhiteSpace(cuerpo))
        {
            Error(ruta, lineaCuerpo, "BLOG008", "La entrada no tiene contenido debajo de la cabecera.");
        }
        else
        {
            var primera = Array.FindIndex(lineas, cierre + 1, l => !string.IsNullOrWhiteSpace(l));
            if (primera >= 0 && lineas[primera].TrimStart().StartsWith("# "))
                Error(ruta, primera + 1, "BLOG009", "No escribas el título con '#': el H1 se genera desde 'titulo' (o desde 'encabezado' si quieres otro texto en el artículo).");
        }

        if (errores > erroresAntes) return null;

        return new Entrada
        {
            Slug = slug,
            Ruta = ruta,
            Cabecera = cabecera,
            Fecha = fecha,
            MomentoPublicacion = tieneHora ? fecha : fecha.Date + HoraPublicacionPorDefecto,
            Cuerpo = cuerpo,
            LineaCuerpo = lineaCuerpo,
        };
    }

    private void ValidarEnlacesInternos(List<Entrada> todas, List<Entrada> publicables)
    {
        var existentes = todas.Select(e => e.Slug).ToHashSet();
        var publicadas = publicables.Select(e => e.Slug).ToHashSet();

        foreach (var entrada in publicables.Where(e => !e.EsComponente))
        {
            var documento = Markdown.Parse(entrada.Cuerpo, pipeline);
            foreach (var enlace in documento.Descendants<LinkInline>())
            {
                var destino = EnlaceAlBlog().Match(enlace.Url ?? "");
                if (!destino.Success) continue;

                var slug = destino.Groups[1].Value;
                var linea = entrada.LineaCuerpo + enlace.Line;
                if (!existentes.Contains(slug))
                    Error(entrada.Ruta, linea, "BLOG011", $"El enlace apunta a una entrada que no existe: '{enlace.Url}'.", enlace.Column + 1);
                else if (!publicadas.Contains(slug))
                    Aviso(entrada.Ruta, linea, "BLOG012", $"El enlace apunta a una entrada que aún no se publica (borrador o programada): '{enlace.Url}'.", enlace.Column + 1);
            }
        }
    }

    private void Escribir(List<Entrada> publicables)
    {
        // Se vacía la carpeta completa: no deben quedar entradas borradas ni marcas de otra configuración.
        if (Directory.Exists(opciones.Salida)) Directory.Delete(opciones.Salida, recursive: true);
        var carpetaArticulos = Path.Combine(opciones.Salida, "articulos");
        Directory.CreateDirectory(carpetaArticulos);

        var utf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        foreach (var entrada in publicables.Where(e => !e.EsComponente))
        {
            var encabezado = EscaparHtml(entrada.Cabecera.Encabezado ?? entrada.Cabecera.Titulo!);
            var html = $"<h1 id=\"titulo-principal\">{encabezado}</h1>\n" + Markdown.ToHtml(entrada.Cuerpo, pipeline);
            File.WriteAllText(Path.Combine(carpetaArticulos, entrada.Slug + ".html"), html, utf8);
        }

        var indice = publicables
            .OrderByDescending(e => e.Fecha)
            .Select(e => new
            {
                Id = e.Slug,
                e.Cabecera.Titulo,
                e.Cabecera.Resumen,
                e.Fecha,
                Autor = e.Cabecera.Autor ?? AutorPorDefecto,
                e.Cabecera.Categoria,
                e.Cabecera.Etiquetas,
                e.Cabecera.Componente,
                e.Cabecera.Borrador,
                e.Programado,
            });

        var json = JsonSerializer.Serialize(indice, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        });
        File.WriteAllText(Path.Combine(opciones.Salida, "posts.json"), json, utf8);
    }

    // Solo lo imprescindible: las tildes y la ñ se dejan tal cual, igual que las escribe Markdig.
    private static string EscaparHtml(string texto) => texto
        .Replace("&", "&amp;")
        .Replace("<", "&lt;")
        .Replace(">", "&gt;")
        .Replace("\"", "&quot;");

    private void Error(string ruta, int linea, string codigo, string mensaje, int columna = 1)
    {
        errores++;
        Console.WriteLine($"{Path.GetFullPath(ruta)}({linea},{columna}): error {codigo}: {mensaje}");
    }

    private static void Aviso(string ruta, int linea, string codigo, string mensaje, int columna = 1) =>
        Console.WriteLine($"{Path.GetFullPath(ruta)}({linea},{columna}): warning {codigo}: {mensaje}");

    [GeneratedRegex("^[a-z0-9][a-z0-9_-]*$")]
    private static partial Regex SlugValido();

    [GeneratedRegex("Property '(.+?)' not found")]
    private static partial Regex CampoDesconocido();

    [GeneratedRegex(@"^/?blog/([^/?#]+)/?(?:[?#].*)?$")]
    private static partial Regex EnlaceAlBlog();
}
