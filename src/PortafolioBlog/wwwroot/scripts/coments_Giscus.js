// Esta función será llamada desde Blazor cada vez que se entra a un post
window.renderGiscus = () => {
    const container = document.getElementById('giscus-container');
    if (!container) return;

    // se limpia el contenedor por si se viene desde otro post
    container.innerHTML = '';

    const script = document.createElement('script');
    script.src = "https://giscus.app/client.js";
    script.setAttribute('data-repo', "WilmerRv1989/WilmerRv1989.github.io");
    script.setAttribute('data-repo-id', "R_kgDOQ0TQMA");
    script.setAttribute('data-category', "General");
    script.setAttribute('data-category-id', "DIC_kwDOQ0TQMM4C04Rn");
    script.setAttribute('data-mapping', "pathname"); // Clave para que cada post sea único
    script.setAttribute('data-strict', "0");
    script.setAttribute('data-reactions-enabled', "1");
    script.setAttribute('data-emit-metadata', "0");
    script.setAttribute('data-input-position', "top");
    script.setAttribute('data-theme', "dark"); // Tema oscuro para tu blog
    script.setAttribute('data-lang', "es");
    script.setAttribute('crossorigin', "anonymous");
    script.async = true;

    container.appendChild(script);
};