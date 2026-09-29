namespace PortafolioBlog.Models
{
    // Una entrada del índice del blog (wwwroot/generado/posts.json), generado desde Contenido/Blog.
    public class PostMetadata
    {
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Resumen { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Autor { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public List<string> Etiquetas { get; set; } = new();

        // Nombre del componente Razor que contiene la entrada; null si la entrada está escrita en Markdown.
        public string? Componente { get; set; }

        // Solo llegan en verdadero en builds de Debug, para revisar en local lo que aún no se publica.
        public bool Borrador { get; set; }
        public bool Programado { get; set; }
    }
}
