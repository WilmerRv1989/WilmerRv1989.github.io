## Hablemos de Estructura de la página y Contenido Accesible

**Nota:** Esta es la primera entrada de una serie dedicada a la accesibilidad web. En esta serie, exploraremos diversos aspectos clave para garantizar que las páginas web sean accesibles para todos los usuarios, incluyendo aquellos con discapacidades. Comenzaremos con la estructura de la página y el contenido accesible, y en futuras entradas abordaremos temas como formularios, textos alternativos, tablas, enlaces y más. esta serie es una re-publicación de contenido que había creado anteriormente en un sitio web dedicado a la accesibilidad, con fines prácticos y educativos que ahora estoy trasladando a este blog personal para llegar a una audiencia más amplia interesada en el tema.

La estructura de una página web es fundamental para garantizar su accesibilidad. Es recomendable utilizar las etiquetas y atributos adecuados proporcionados por `HTML` para este propósito. `HTML` ofrece etiquetas contextuales específicas para cada región de una página web. Además, en casos especiales, podemos utilizar roles de `ARIA` para mejorar el marcado semántico del contenido de la página que estamos creando.

En esta sección, examinaremos cómo establecer las regiones de una página web, así como la estructura correcta del contenido, incluyendo encabezados, contenido semántico y otros elementos importantes.

## Idioma de la página (lang)

Para comenzar, lo primero que debemos de tener en cuenta, es fundamental indicar el idioma principal de tu página web para mejorar la accesibilidad y la experiencia del usuario. Al declarar el idioma, los navegadores y las tecnologías de asistencia, como los lectores de pantalla, pueden renderizar el contenido de forma más precisa, utilizando la pronunciación y las reglas gramaticales adecuadas. Esto evita que el lector de pantalla intente leer el texto en el idioma incorrecto, lo que resultaría en una experiencia confusa e incomprensible para el usuario.

Además de declarar el idioma principal, si tienes secciones o frases en un idioma diferente dentro de tu contenido, es importante marcarlas explícitamente. Esto permite que las herramientas de asistencia cambien la configuración de idioma al leer esas partes específicas, garantizando que todo el contenido sea accesible y comprensible.

### Código

```html
<html lang="es">
    <head>
        <!-- Tu meta información, título, enlaces a CSS, etc. -->
    </head>
    <body>
        <!-- Todo el contenido de tu página va aquí -->
        <p>Este es un párrafo en español. El poeta dijo <q lang="en">Poetry is the language of the soul</q>, una frase que resuena en los corazones de muchos.</p>
    </body>
</html>
```

### Explicación:

El atributo **`lang="es"`** en la etiqueta `<html>` indica que el idioma principal de todo el documento es el español. Si tienes un fragmento de texto en otro idioma, como el ejemplo de la cita en inglés, puedes usar el atributo **`lang="en"`** directamente en la etiqueta que contiene ese texto (`<q>` en este caso) para especificar el cambio de idioma solo para esa porción y así con cualquier texto o elemento que esté en otro idioma.

## Título de página (title)

El título de una página web es el texto que se muestra en la pestaña del navegador. Es un mecanismo de orientación fundamental que, lamentablemente, con el paso del tiempo ha recibido menos atención. En páginas web del tipo "Single Page Application" (SPA) es incluso común que sus creadores no sepan cómo modificar o controlar dinámicamente este título según el contenido visible en pantalla.

Sin embargo, el título de una página web es un elemento de navegación muy útil para personas con discapacidad, quienes pueden tener dificultades para comprender o ubicarse fácilmente en un sitio web.

Para crear títulos de página adecuados, no basta con dejar el nombre del sitio web fijo para todo el contenido, sin importar en qué parte nos encontremos. Se deben tener en cuenta algunos elementos clave:

* Un título adecuado debe identificar claramente el propósito y el contenido de la página que se está consultando.
* Usar un título único para todo el sitio web, sin importar el contenido o el cambio de contexto o pantalla, no es una práctica adecuada. Por ejemplo, limitarse al nombre de nuestra empresa sin ningún elemento adicional que refleje el contexto de la pantalla actual en la que se encuentra el usuario.

Estos elementos se vuelven cada vez más relevantes a medida que aumenta la complejidad de nuestra página web. Por ejemplo, en un sitio web de ventas, un usuario puede acceder a la lista de productos, la vista de un producto específico, el carrito de la compra, pasarelas de pago, su perfil personal, historiales de compra, etc.

En todos esos casos, mantener un título genérico (como solo el nombre de la empresa de ventas) no será accesible ni adecuado. Será necesario cambiar dinámicamente el título de la página para reflejar el contexto donde se encuentre el usuario. Por ejemplo: "Empresa - Productos - Producto consultado", según corresponda para cada sección del sitio.

De esta manera, una persona puede comprender rápidamente dónde se encuentra y qué contenido principal se espera en la página web a medida que navega y revisa el título.

Para establecer el título de una página, lo hacemos desde el documento `HTML` de nuestro sitio en la sección `<head>` y se utiliza la etiqueta `<title>`.

### Código HTML

```html
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tu Empresa - Página Principal</title>
    <!-- Otros elementos del head -->
</head>
<body>
    <!-- Contenido de la página -->
</body>
</html>
```

**Nota:** Esta solución solo es viable en proyectos donde tenemos control total del código `HTML` que se envía al navegador. En proyectos de "Single Page Applications" (SPAs) como React o Angular, necesitamos usar JavaScript para actualizar el valor del título de la página de forma dinámica. La propiedad `document.title` nos proporciona esta posibilidad. Por ejemplo, la siguiente función en JavaScript puede actualizar el título de la página cuando el usuario visualiza un producto:

### Código JavaScript

```javascript
function actualizarTituloConProducto(nombreProducto) {
    document.title = "Tu Empresa - Tienda - " + nombreProducto;
}

// Ejemplo de uso:
// Si el usuario está viendo "Disfraz de pingüino "
// actualizarTituloConProducto("Disfraz de pingüino");
// El título de la pestaña se convertirá en "Tu Empresa - Tienda - Disfraz de pingüino"
```

De esta manera, con una simple función podemos actualizar el título de la página cada vez que se carga un nuevo componente o cambia la vista. Incluso podemos crear un servicio o _helper_ al que llamaremos cada vez que necesitemos actualizar el título para mantener la consistencia en toda la aplicación.

## Encabezado de página (Header)

La mayoría de las páginas web tienen una región en la parte superior conocida como encabezado de página. En esta sección, se suelen incluir elementos como el logotipo del sitio, el título de la página y las funciones de navegación, como los enlaces de menú y la barra de búsqueda. `HTML` proporciona la etiqueta `<header>` para esta región, que es identificada correctamente por las herramientas de apoyo.

### Código

```html
        <header>
            <p>Este es el encabezado de la página web</p>
        </header>
```

## Menú de navegación (Nav)

`HTML` también proporciona etiquetado para establecer los menús de navegación, utilizando la etiqueta `<nav>`. Una página web puede tener más de un menú de navegación, pero se recomienda no abusar de ellos para evitar confundir al usuario.

Si usamos varios menús de navegación, es importante etiquetarlos correctamente utilizando roles de ARIA para diferenciarlos y facilitar la navegación a los usuarios de herramientas de apoyo.

### Código

```html
        <nav>
    <ul>
        <li><a href="/">Inicio</a></li>
        <li><a href="/proyectos">Proyectos</a></li>
        <li><a href="/blog">Blog</a></li>
        <li><a href="/contacto">Contacto</a></li>
    </ul>
</nav>
```

## Contenido principal (Main)

Para el contenido principal de una página web, se utiliza la etiqueta `<main>`. Esta marca dónde comienza y termina la región principal de la página, y aquí es donde se coloca todo el contenido que se quiere transmitir al usuario: títulos, texto, imágenes, formularios, etc.

### Código

```html
        <main>
            <p>Aquí va el contenido principal de la página web</p>
        </main>
```

## Contenido complementario (Aside)

Dentro del contenido principal de la página web, también contamos con la etiqueta `<aside>`, que nos permite agregar contenido adicional que se explique por sí mismo o complemente el contenido de la región principal. Esta etiqueta se utiliza para agregar información adicional, como artículos complementarios, acceso a otras páginas relevantes del sitio, acceso a redes sociales, entre otros. Este contenido se coloca normalmente después de la región principal.

### Código

```html
        <aside>
            <p>Aquí podemos colocar la información complementaria a la región principal</p>
        </aside>
```

## Pie de página (Footer)

Por último, debemos marcar la región del pie de página de nuestro sitio web. `HTML` proporciona la etiqueta `<footer>` para este fin. Normalmente, en esta sección se suelen incluir los derechos de autor, licencias, declaraciones de conformidad, aspectos legales, enlaces de interés y todo aquel contenido complementario al sitio web.

### Código

```html
        <footer>
            <p>Aquí se coloca toda la información referida al pie de página del sitio web</p>
        </footer>
```

## Conclusiones sobre el etiquetado de regiones

Marcar las regiones de nuestra página web permite a los usuarios de herramientas de apoyo navegar de forma rápida por cada sección si estas están correctamente etiquetadas. Los lectores de pantalla, como NVDA, cuentan con teclas rápidas que permiten a los usuarios hacer saltos por cada región.

Algunos consejos y consideraciones respecto a las regiones que es bueno tener en cuenta son los siguientes:

* Mantenga siempre la misma estructura para las distintas páginas que componen el sitio web. Esto permite crear familiaridad en el usuario y consistencia en el sitio.
* Etiquete todas las regiones de forma ordenada y no deje sin usar ninguna de las etiquetas de región proporcionadas por HTML5.
* En los menús de navegación, utilice un menú simple y bien organizado. Marque la página actual para los usuarios de herramientas de apoyo, utilizando roles de ARIA tanto para indicar la página actual como para etiquetar varios menús de navegación en páginas con más de uno.
* Recuerde que las regiones correctamente marcadas son las que utilizarán los usuarios de herramientas de apoyo para ubicarse dentro del sitio web.

Estos son algunos puntos clave a considerar al etiquetar las regiones de una página web para garantizar una experiencia de usuario accesible y coherente.

## Uso de encabezados

Los encabezados desempeñan un papel crucial en la organización del contenido dentro de la región principal de una página web. Son utilizados por los usuarios que emplean herramientas de apoyo para navegar por el contenido proporcionado.

Es fundamental mantener una jerarquía coherente de encabezados en la página web. Se debe utilizar una jerarquía adecuada para agrupar secuencialmente los encabezados, comenzando con el encabezado más importante, que es el encabezado principal o H1, seguido por el resto de encabezados en orden.

Un encabezado de nivel 2 o H2 abre una nueva sección dentro del contenido principal de la página, mientras que un encabezado de nivel 3 o H3 abre una subsección del encabezado anterior (H2), y así sucesivamente.

Es importante no saltar niveles en la jerarquía de encabezados. Por ejemplo, no se debe pasar de un H2 a un H4 o H5 sin haber pasado por los niveles intermedios. Sin embargo, está permitido retroceder en la jerarquía de encabezados al cerrar una subsección, por ejemplo, al terminar un subcapítulo marcado con H4 y regresar a H2 para iniciar una nueva sección dentro de la página.

Para ilustrar lo mencionado anteriormente, aquí hay un ejemplo de cómo estructurar la jerarquía de encabezados:

### Ejemplo de jerarquía de encabezados:

# Título 1

Texto que abre la sección principal

## Título 2

Texto que inicia un capítulo dentro de la región principal

### Título 3

Texto que abre una subsección del capítulo o sección

#### Título 4

Subapartado el cual está subordinado al Título 3

## Nuevo Título 2

Título que abre una nueva sección aparte del conjunto anterior

### Código

```html
    <h1>Título 1</h1>
    <p>Texto que abre la sección principal</p>
        <h2>Título 2</h2>
        <p>Texto que inicia un capítulo dentro de la región principal</p>
            <h3>Título 3</h3>
            <p>Texto que abre una subsección del capítulo o sección</p>
                <h4>Título 4</h4>
                <p>sub apartado el cual esta subordinado al título 3</p>
    <h2>Nuevo Título 2</h2>
    <p>título que abre una nueva sección aparte del conjunto anterior</p>
```

### Explicación:

El ejemplo anterior ilustra un uso correcto de la jerarquía de encabezados dentro de una página web. La cantidad y nivel de encabezados necesarios dependerán del orden y la relación entre los diferentes apartados de la página. Esto queda a discreción del creador de la página, siempre y cuando se respete el orden lógico de la jerarquía de encabezados.

Es común encontrar páginas web donde se utiliza texto de encabezado para marcar contenido que no lo es, simplemente por el estilo predeterminado de los encabezados o por una incorrecta jerarquía en la presentación de la información. Todos estos usos son incorrectos, ya que dificultan la navegación para los usuarios de herramientas de apoyo, como lectores de pantalla.

## Contenido correctamente estructurado

El contenido de una página web debe estar marcado semánticamente, es decir, toda la información de la región principal que será consumida por los usuarios debe estar marcada de acuerdo al tipo de contenido que se esté presentando.

Para lograr esto, utilizamos diversas etiquetas que `HTML` ofrece para diferentes tipos de contenido. A continuación, se presenta una lista de las etiquetas más comunes y sus usos:

### Article

La etiqueta `<article>` se utiliza para marcar contenido como un artículo independiente en una página, como un artículo de una página de ventas o el artículo principal de una página de noticias en un medio informativo.

### Código

```html
    <article>
        <h2>Artículo</h2>
        <p>Sección de un artículo</p>
    </article>
```

### Section

La etiqueta `<section>` marca el inicio de una sección general de una página web dentro de la región principal; se utiliza para la agrupación temática del contenido.

### Código

```html
    <section>
        <h2>Capítulo 1</h2>
        <p>Érase una vez en un lugar de La Mancha... </p>
    </section>
```

### Párrafos

`<p>` se utiliza para marcar los párrafos de texto plano que componen la página web. Por ejemplo, este párrafo que estás leyendo se encuentra marcado mediante esta etiqueta.

### Cita en bloque

`<blockquote>` se utiliza para marcar bloques de citas, muy útil para referenciar textos de autores. Estas citas son leídas por las herramientas de apoyo, ayudando a evitar confusiones en la lectura del texto citado, ya que se menciona tanto el inicio como el cierre de la cita.

### Ejemplo de cita en bloque

> "En tres tiempos se divide la vida: en presente, pasado y futuro. De éstos, el presente es brevísimo; el futuro, dudoso; el pasado, cierto. De lo que poseemos, una mínima parte es la que está en nuestras manos; lo demás es ajeno. Y aun esa mínima parte, que llamamos presente, se nos escurre entre las manos mientras hablamos de ella. Pues mientras digo esto, ya una parte ha pasado; mientras lo dispongo, ya se ha desvanecido. De tal modo que la vida es fugaz, y, por si fuera poco, gran parte de ella se nos escapa sin vivirla."
> 
> Séneca: Sobre la brevedad de la vida
 
### Código

```html
    <blockquote>
        <p>"En tres tiempos se divide la vida: en presente, pasado y futuro. De éstos, el presente es brevísimo; el futuro, dudoso; el pasado, cierto. De lo que poseemos, una mínima parte es la que está en nuestras manos; lo demás es ajeno. Y aun esa mínima parte, que llamamos presente, se nos escurre entre las manos mientras hablamos de ella. Pues mientras digo esto, ya una parte ha pasado; mientras lo dispongo, ya se ha desvanecido. De tal modo que la vida es fugaz, y, por si fuera poco, gran parte de ella se nos escapa sin vivirla."</p>
        <cite>Séneca: Sobre la brevedad de la vida</cite>
    </blockquote>
```

### Cita dentro de un párrafo de texto

La etiqueta `<q>` se utiliza para marcar citas dentro de un párrafo de texto, agregando un resaltado visual específico para el texto de la cita.

### Código

```html
    <p>El poeta dijo <q>La poesía es el lenguaje del alma</q>, una frase que resuena en los corazones de muchos.</p>
```

### Listas desordenadas

Utilice la etiqueta `<ul>` para crear listas desordenadas. Las listas desordenadas se utilizan cuando no hay una relación de jerarquía entre los elementos; estas serán leídas por las herramientas de apoyo como viñetas.

### Ejemplo de lista desordenada

* Elemento 1
* Elemento 2
* Elemento 3
 
### Código

```html
    <ul>
        <li>Elemento 1</li>
        <li>Elemento 2</li>
        <li>Elemento 3</li>
    </ul>
```

### Listas ordenadas

Utilice la etiqueta `<ol>` para crear listas ordenadas. Las listas ordenadas o numeradas se utilizan para marcar una relación de jerarquía entre los elementos. Se enumeran de forma automática y las herramientas de apoyo las leerán en ese orden.

### Ejemplo de lista ordenada

1. Elemento 1
2. Elemento 2
3. Elemento 3

  ### Código

```html
    <ol>
        <li>Elemento 1</li>
        <li>Elemento 2</li>
        <li>Elemento 3</li>
    </ol>
```

### Listas de definiciones o descripciones

Utilice la etiqueta `<dl>` para crear listas de definiciones o descripciones. Se trata de listas cuyo uso es para establecer conceptos acompañados de una definición del mismo. Se utiliza `<dt>` para marcar el concepto a definir o describir y `<dd>` para marcar el texto de la definición o descripción.
  
### Código

```html
    <dl>
        <dt>HTML</dt>
        <dd>HTML (HyperText Markup Language) es el lenguaje de marcado estándar utilizado para crear páginas web y aplicaciones web.</dd>

        <dt>CSS</dt>
        <dd>CSS (Cascading Style Sheets) es un lenguaje utilizado para describir la presentación de un documento HTML. Define el diseño, los colores y otros aspectos de la apariencia de un documento web.</dd>
    </dl>
```

Al combinar estas etiquetas de manera adecuada y coherente, se puede crear una página web bien organizada, fácil de leer y navegar. Esto mejora la experiencia del usuario y la accesibilidad del contenido para aquellos que utilizan herramientas de apoyo. Se recomienda su uso consciente y respetando los parámetros de accesibilidad recomendados.

## Conclusiones Generales

En esta entrada, hemos explorado la estructura fundamental de una página web y su papel crucial para garantizar la accesibilidad. Iniciamos con la declaración del idioma (`lang`), un paso esencial que permite a los lectores de pantalla interpretar el contenido de forma precisa. Continuamos con el uso estratégico del título de la página (`<title>`), que actúa como una brújula, no solo para la orientación inmediata en el navegador, sino también para facilitar la navegación por el historial y la gestión de favoritos.

Además, examinamos cómo las etiquetas semánticas de `HTML` (como `<header>`, `<nav>`, `<main>`, `<aside>` y `<footer>`) no solo organizan visualmente el contenido, sino que, de manera más relevante, definen regiones y roles que las tecnologías de asistencia comprenden y utilizan para permitir una navegación rápida y eficiente. La jerarquía adecuada de los encabezados (H1-H6) asegura un flujo lógico y navegable dentro del contenido principal de la página.

Finalmente, abordamos la importancia de emplear correctamente las etiquetas para el contenido estructurado, incluyendo párrafos, citas en bloque y en línea, así como los distintos tipos de listas (ordenadas, desordenadas y de definición). Esto garantiza que la información se presente de forma clara, coherente y semánticamente rica, beneficiando tanto a los usuarios de herramientas de apoyo como a cualquier persona que acceda al contenido.

Aplicar estas prácticas de manera consciente y consistente es la base para construir sitios web que sean verdaderamente inclusivos y accesibles, permitiendo que cualquier usuario, sin importar sus capacidades, pueda acceder e interactuar con el contenido de forma efectiva.

Gracias por leer esta entrada, que como les contaba, es la primera de una serie dedicada a la accesibilidad web que formaba parte de el sitio web #HablemosDeAccesibilidad que habia hecho hace un tiempo con fines practicos y educativos, y que ahora estoy re-publicando en este blog personal para que llegue a más gente interesada en el tema. espero que les haya sido de utilidad y nos vemos en la próxima entrega donde hablaremos de otros aspectos importantes de la accesibilidad web. ¡Hasta la próxima miches!