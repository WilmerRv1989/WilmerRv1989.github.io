# Análisis del proyecto PortafolioBlog

## Resumen general

Proyecto Blazor WebAssembly (.NET 8) para portafolio personal con blog de accesibilidad. Usa `wwwroot/data/posts.json` como índice de metadatos y carga artículos en Markdown desde `wwwroot/articles`. Diseño con Bootstrap, ruteo de Blazor y layout simple. Objetivo: publicar en GitHub Pages (repositorio de usuario).

## Estado actual (verificado)

- Framework: .NET 8 (`TargetFramework=net8.0`).
- Paquetes: `Microsoft.AspNetCore.Components.WebAssembly 8.0.22`, `DevServer 8.0.22`, `Markdig 0.44.0`.
- Páginas: `Home`, `BlogIndexPage`, `Post`. Layout: `MainLayout` + `NavMenu`.
- Datos: `wwwroot/data/posts.json` (1 artículo) y `wwwroot/articles/*.md`.
- Modelo: `PostMetadata` incluye `Categoria` además de `Etiquetas`.
- PWA: `manifest.webmanifest`, `service-worker.js` y `ServiceWorkerAssetsManifest` configurados.
- Head: `HeadOutlet` presente en `Program.cs`.
- Publicación: repo `WilmerRv1989.github.io` (user site). `base href="/"` es correcto para este tipo de publicación.

## Cambios aplicados (resueltos)

- Formato de fecha corregido en `BlogIndexPage.razor`.
- Carga de Markdown coherente con `articles/{ArticleName}.md`.
- `wwwroot/404.html` agregado para fallback de SPA en GitHub Pages.
- Enlaces del índice del blog migrados a `NavLink` para navegación SPA sin recarga.

## Observaciones técnicas pendientes

1) Accesibilidad
- Buenas bases (`PageTitle`, feedback de carga). Pendiente:
  - Skip?link (“Saltar al contenido”) antes de `main`.
  - Landmarks semánticos (`header`, `nav`, `main`, `footer`) en `MainLayout`.
  - Estilos `:focus-visible` en enlaces/botones y contraste.
  - Ajustar badges de etiquetas (evitar el punto final innecesario y mejorar texto accesible si aplica).

2) SEO/Head
- Faltan `meta description`, `og:*` y `twitter:*` por página (inyectables con `HeadContent`). 
- No hay `sitemap.xml` ni `robots.txt`.

3) Estilos Markdown
- Añadir CSS para `pre/code`, tablas y citas para legibilidad y contraste.

4) Publicación/CI
- No hay workflow de deploy a GitHub Pages ni script local de publicación.

## Potencial

- Base adecuada para posicionamiento en .NET y accesibilidad.
- Escalable con secciones de Proyectos, Casos de estudio y Auditorías WCAG.
- Componentización en Blazor facilita reutilización (tarjetas, badges, visor Markdown).

## Mejoras necesarias (alta prioridad)

- Ninguna crítica inmediata tras los cambios. Priorizar accesibilidad base y SEO.

## Mejoras recomendadas (medio plazo)

- Accesibilidad: skip?link, landmarks y foco visible; revisar contraste.
- SEO/Head: meta tags por página, `sitemap.xml`, `robots.txt`.
- UX/Contenido: página “Proyectos” y “Sobre mí”; filtro por etiquetas.
- Código: `services/IPostService` para lectura/cache de `posts.json` y manejo de errores centralizado; componentes `PostCard`, `TagBadge`, `MarkdownViewer`.
- Build/Deploy: workflow de GitHub Actions para build y deploy (a raíz o a `docs/`); script local `publish.ps1`.

## Escalabilidad

- Con ~100+ posts: paginación y búsqueda local.
- Internacionalización ES/EN: cadenas y slugs bilingües.
- Generación automática de índice (`posts.json`) en CI si crece el volumen.

## Roadmap sugerido

1) Accesibilidad base: skip?link, landmarks, foco visible; estilos Markdown.
2) SEO básico: meta tags + `sitemap.xml`/`robots.txt`.
3) Páginas de Proyectos y Sobre mí con 3–5 casos bien documentados.
4) Workflow de deploy automatizado a GitHub Pages.

## Conclusión

Proyecto sólido y bien encaminado. Con mejoras de accesibilidad/SEO y despliegue automatizado, quedará listo para producción y para crecer con más contenido técnico.