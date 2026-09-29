---
titulo: "Tablas de datos accesibles"
encabezado: "Hablemos de Uso de tablas"
resumen: "Creación de tablas accesibles con encabezados y estructura semántica."
fecha: 2026-01-11
categoria: "Accesibilidad web"
etiquetas: ["Tablas", "ARIA", "Datos"]
---

Nota: Esta es la última entrada de una serie dedicada a la accesibilidad web. En esta serie exploramos diversos aspectos clave para garantizar que las páginas web sean accesibles para todos los usuarios, incluyendo aquellos con discapacidades. En esta entrada de cierre hablaremos del uso de tablas de datos correctamente marcadas para la accesibilidad. Esta serie es una re-publicación de contenido que había creado anteriormente en un sitio web dedicado a la accesibilidad, con fines prácticos y educativos que ahora estoy trasladando a este blog personal para llegar a una audiencia más amplia interesada en el tema.

Las tablas son elementos de una página web que permiten organizar contenido de manera lógica al relacionar los datos entre filas y columnas. Para que este contenido sea accesible, es fundamental marcar las relaciones entre los datos y los encabezados de las filas y columnas. Esto permite que las herramientas de apoyo puedan identificar y transmitir esta información al usuario de manera adecuada.

La forma en que se deben relacionar los encabezados de una tabla con los datos proporcionados dependerá de la estructura de los datos en la tabla. Ya sea que la tabla tenga una fila de encabezados, una columna de encabezados o más de una, el proceso de etiquetado para garantizar la accesibilidad variará en consecuencia.

Para un marcado correcto, las celdas de encabezado de una tabla deben marcarse con &lt;th&gt; y las celdas de contenido de los datos con &lt;td&gt;. En tablas con relaciones más complejas, se deben emplear otras técnicas de marcado, como ‘scope’ y atributos como  ‘id’ para definir los encabezados correspondientes.

## Título de la tabla (caption)

Lo primero a mencionar es que toda tabla de datos presentada al usuario debe llevar un título que identifique la tabla. Para este fin, contamos con la etiqueta &lt;caption&gt;, la cual debe ser declarada justo después de abrir la etiqueta &lt;table&gt; y antes de comenzar a escribir las filas de la tabla.

Los títulos de las tablas deben proporcionar información clara sobre la finalidad de los datos presentados, ya que este será lo primero que se lea cuando el usuario llegue a la tabla si usa herramientas de apoyo como lectores de pantalla. Veamos un ejemplo simple de un título de tabla:

### Ejemplo de título de tabla

```html demo sin-estilos
<table class="table-bordered">
    <caption class="caption-top">Resumen de ventas primer trimestre del año</caption>
    <thead>
        <tr>
            <th>Mes</th>
            <th>Ventas camisetas</th>
            <th>Ventas pantalones</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Enero</td>
            <td>1500</td>
            <td>2000</td>
        </tr>
        <tr>
            <td>Febrero</td>
            <td>1800</td>
            <td>1500</td>
        </tr>
        <tr>
            <td>Marzo</td>
            <td>3400</td>
            <td>2900</td>
        </tr>
    </tbody>
</table>
```

Nota: En los siguientes ejemplos, al mostrar el código en el apartado correspondiente, se omite la línea de código referida al título, con la única finalidad de abreviar y prestar atención a la técnica mostrada.

## Tablas con una fila de encabezado

En tablas con una única fila de encabezado, la fila de encabezado debe marcarse con &lt;th&gt;. Este tipo de tablas suele ser simple y fácil de leer, ya que los datos se relacionan directamente con la fila de encabezado correspondiente. Veamos un ejemplo:

### Ejemplo de tabla con fila de encabezado

```html demo sin-estilos
<table class="table-bordered">
    <caption class="table caption-top" data-demo-oculto>Cursos y horarios</caption>
    <tr>
        <th>Ciclo lectivo</th>
        <th>Curso</th>
        <th>Duración</th>
        <th>Horario</th>
    </tr>
    <tr>
        <td>I ciclo</td>
        <td>Cocina 1</td>
        <td>12 semanas</td>
        <td>De 9am a 12md.</td>
    </tr>
    <tr>
        <td>I ciclo</td>
        <td>Matemática 1</td>
        <td>8 semanas</td>
        <td>de 7am a 10am</td>
    </tr>
    <tr>
        <td>II ciclo</td>
        <td>Arreglos florales</td>
        <td>4 semanas</td>
        <td>De 1pm a 4pm</td>
    </tr>
    <tr>
        <td>II ciclo</td>
        <td>Finanzas 1</td>
        <td>7 semanas</td>
        <td>De 1pm a 4pm</td>
    </tr>
</table>
```

### Explicación

En el ejemplo anterior, solo se marca la primera fila como fila de encabezados. Las herramientas de apoyo como lectores de pantalla leerán el título de la columna junto con el dato correspondiente a medida que nos movamos en cada fila de la tabla.

## Tablas con una columna de encabezado

En tablas donde la primera columna funcione como columna de encabezado, deberemos marcar la primera celda de cada fila con &lt;th&gt;. De esta manera, la tabla será leída de forma correcta por las herramientas de apoyo. Veamos un ejemplo sencillo:

### Ejemplo de tabla con una columna de encabezado

```html demo sin-estilos
<table class="table-bordered">
    <caption class="table caption-top" data-demo-oculto>Cursos y horarios</caption>
    <tr>
        <th>Ciclo lectivo</th>
        <td>I ciclo</td>
        <td>I ciclo</td>
        <td>II ciclo</td>
        <td>II ciclo</td>
    </tr>
    <tr>
        <th>Curso</th>
        <td>Cocina 1</td>
        <td>Matemática 1</td>
        <td>Arreglos florales</td>
        <td>Finanzas 1</td>
    </tr>
    <tr>
        <th>Duración</th>
        <td>12 semanas</td>
        <td>8 semanas</td>
        <td>4 semanas</td>
        <td>7 semanas</td>
    </tr>
    <tr>
        <th>Horario</th>
        <td>De 9am a 12md.</td>
        <td>de 7am a 10am</td>
        <td>De 1pm a 4pm</td>
        <td>De 1pm a 4pm</td>
    </tr>
</table>
```

### Explicación

En este caso, proporcionamos el mismo ejemplo que en el apartado anterior, pero esta vez, la primera columna tiene los títulos de encabezado de la tabla. En este caso, las herramientas de apoyo leerán primero el título de la columna de encabezado y luego los datos de la fila correspondiente. Si el usuario se desplaza entre celdas de la misma columna directamente, primero escuchará el título y luego el dato de la celda enfocada.

## Tabla con fila y columna de encabezado

En aquellas tablas donde la relación de los encabezados sea tanto horizontal como verticalmente, es necesario marcar tanto la fila de encabezado como la columna de encabezado. Dado que se trata de una tabla cuya relación es relativamente ambigua, se debe utilizar el atributo 'scope' para establecer la fila o columna a la cual remite la celda de encabezado.

En el siguiente ejemplo, la primera fila de la tabla contiene los días de la semana y la primera columna contiene los tiempos de comida. El resto de celdas contiene los datos asociados a los días y tiempos de comida.

### Ejemplo de tabla con fila y columna de encabezado

```html demo sin-estilos
<table class="table-bordered">
    <caption class="table caption-top" data-demo-oculto>Menú de la semana</caption>
    <tr>
        <th scope="col">Tiempos de comida</th>
        <th scope="col">Lunes</th>
        <th scope="col">Martes</th>
        <th scope="col">Miércoles</th>
        <th scope="col">Jueves</th>
        <th scope="col">Viernes</th>
    </tr>
    <tr>
        <th scope="row">Desayuno</th>
        <td>Tostadas con aguacate</td>
        <td>Huevos revueltos con tocino</td>
        <td>Smoothie de frutas</td>
        <td>Omelette de champiñones</td>
        <td>Pancakes con sirope de arce</td>
    </tr>
    <tr>
        <th scope="row">Almuerzo</th>
        <td>Ensalada César</td>
        <td>Sándwich de pavo</td>
        <td>Pechuga de pollo a la parrilla</td>
        <td>Ensalada griega</td>
        <td>Wrap de pollo</td>
    </tr>
    <tr>
        <th scope="row">Cena</th>
        <td>Pollo asado con verduras</td>
        <td>Pasta Alfredo</td>
        <td>Ensalada de salmón</td>
        <td>Sopa de tomate</td>
        <td>Pizza casera</td>
    </tr>
</table>
```

### Explicación

En esta tabla, la lectura de los encabezados se hará según la forma en cómo el usuario del lector de pantalla navegue por la misma. En caso de moverse sobre la misma fila, se leerá primero el encabezado asociado al día de la columna correspondiente y luego el dato enfocado. Si la lectura se hace sobre la misma columna, primero se leerá el encabezado asociado al tiempo de comida de la fila en la que se encuentre y luego el dato de la celda enfocada. En cualquiera de las dos situaciones, el marcado de las celdas de encabezado permite que se haga una navegación comprensible del contenido.

## Tablas con encabezados de varios niveles

En el caso de las tablas con encabezados de varios niveles, estos pueden abarcar más de una fila o columna de la tabla. Se utilizan para especificar que un conjunto de datos y su encabezado están subordinados a otro encabezado de mayor nivel, que puede o no abarcar más de una fila o columna.

Cuando la tabla contiene encabezados de fila que abarcan varias celdas, se debe establecer la relación mediante la etiqueta &lt;colgroup&gt;. Esta etiqueta se debe colocar al inicio de la tabla y se debe especificar el número de celdas que abarca ese encabezado mediante el atributo 'span'.

A continuación, se presenta un ejemplo que muestra una parte de una tabla más grande que representa la cantidad de personas con discapacidad que utilizan o no la computadora. Se establece una relación de varias columnas para indicar los números porcentuales y totales de personas que utilizan o no la computadora.

### Ejemplo de tabla con encabezados de varios niveles

```html demo
<table class="table border">
    <caption class="caption-top" data-demo-oculto>Cantidad de personas con discapacidad que usan o no la computadora ordenado por grupo etario y edad.</caption>
    <col />
    <colgroup span="2"></colgroup>
    <colgroup span="2"></colgroup>
    <tr>
        <th rowspan="2">Grupo etario y sexo</th>
        <th colspan="2" scope="colgroup">No usa computadora</th>
        <th colspan="2" scope="colgroup">Si usa computadora</th>
    </tr>
    <tr>
        <th scope="col">Absolutos</th>
        <th scope="col">Relativos</th>
        <th scope="col">Absolutos</th>
        <th scope="col">Relativos</th>
    </tr>
    <tr>
        <th scope="row">18 a 35 años</th>
        <td>59223</td>
        <td>1,8</td>
        <td>61286</td>
        <td>36,4</td>
    </tr>
    <tr>
        <th scope="row">Hombres</th>
        <td>20690</td>
        <td>4,1</td>
        <td>23923</td>
        <td>14,2</td>
    </tr>
    <tr>
        <th scope="row">Mujeres</th>
        <td>38533</td>
        <td>7,7</td>
        <td>37363</td>
        <td>22,2</td>
    </tr>
</table>
<p data-demo-oculto>NOTA: la tabla anterior solo es de ejemplo, los valores utilizados no son reales.</p>
```

En el siguiente ejemplo se presenta una tabla con encabezados que abarcan varias filas de la tabla. Además de esto, la tabla cuenta con una fila de encabezados que también tiene celdas que abarcan varias columnas. En este caso, se utiliza &lt;thead&gt; para agrupar la fila de encabezado y luego se especifican los encabezados de fila mediante el atributo ‘scope="rowgroup"’, esto en el &lt;tbody&gt;. De esta manera, se asegura que la relación entre encabezados y filas sea coherente para el usuario al leer la tabla.

Además de esto, para asegurarse de que las filas de encabezados se han relacionado correctamente con el conjunto de celdas a las cuales se hace referencia, se agrupan mediante &lt;tbody&gt; cada grupo. De esta forma, se separa el contenido y se asegura su correcta relación.

### Ejemplo de tabla con encabezados de varias filas

```html demo sin-estilos
<table class="table-bordered">
    <caption class="caption-top" data-demo-oculto>Tallas de camisetas disponibles</caption>
    <thead>
        <tr>
            <th scope="col">Camiseta</th>
            <th scope="col">Color disponible</th>
            <th colspan="3" scope="colgroup">Tallas disponibles</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <th rowspan="3" scope="rowgroup">Señor de los anillos</th>
            <td>Blanco</td>
            <td>M</td>
            <td>L</td>
            <td>XL</td>
        </tr>
        <tr>
            <td>Negro</td>
            <td>S</td>
            <td>M</td>
            <td>L</td>
        </tr>
        <tr>
            <td>Rojo</td>
            <td>S</td>
            <td>XL</td>
            <td>XXL</td>
        </tr>
    </tbody>
    <tbody>
        <tr>
            <th rowspan="2" scope="rowgroup">Star Wars</th>
            <td>Negro con blanco</td>
            <td>S</td>
            <td>M</td>
            <td>XL</td>
        </tr>
        <tr>
            <td>Negro</td>
            <td>S</td>
            <td>M</td>
            <td>L</td>
        </tr>
    </tbody>
</table>
```

### Explicación

En los ejemplos anteriores, se presentan distintas técnicas de programación que buscan que tablas con relaciones de encabezados complejos estén bien estructuradas y relacionadas en el código. De esta manera, los usuarios de herramientas de apoyo podrán hacer una lectura lógica de la tabla.

En el primer caso, cuando el usuario esté leyendo los datos de la tabla y alterne entre columnas, primero se leerá el encabezado de mayor nivel, luego el segundo y finalmente el dato. Por ejemplo: “No usa computadora, absolutos, 59223”.

En el segundo caso, ocurre algo similar. Al interactuar con cada celda de los datos, primero se leerá el encabezado de grupo de fila, luego el encabezado de la fila superior y por último el dato. Por ejemplo: “Señor de los anillos, Color disponible, blanco”.

En ambos casos, la lectura realizada por la herramienta de apoyo, como lectores de pantalla, puede variar según el navegador empleado y la configuración de lectura que tenga el usuario de dicho lector.

Como las tablas de encabezados cuyas relaciones con los datos son complejas, se recomienda tener en cuenta los siguientes consejos:

- Si requieres usar tablas complejas, asegúrate de agregar resúmenes de las tablas antes de presentar la tabla en cuestión. Esto permitirá a los usuarios hacerse una idea de cómo debe ser leída la información comprendida en la tabla y cómo se relacionan los datos entre sí.
- Como se acaba de mostrar, las tablas complejas representan un reto de diseño y programación. Por lo tanto, en la medida de lo posible, divide tablas complejas en tablas de datos más simples. A menudo es posible desglosar tablas complejas en tablas más sencillas y fáciles de seguir.
- Asegúrate de que cada dato se encuentre relacionado de forma correcta con su encabezado. En la medida de lo posible, no combines celdas de datos cuando sean iguales; es mejor repetir el dato. Las celdas de datos deben ser únicas y no deben usarse de la misma forma en que relacionamos los encabezados y sus niveles.
- En la medida de lo posible, alinea los datos de texto a la izquierda y los datos numéricos a la derecha de la celda correspondiente. También, considera usar estilos que alternen el color de filas pares e impares para mejorar la lectura visual, siempre y cuando dichos contrastes respeten criterios de accesibilidad.
- No uses tablas para maquetar diseño en una página web. Las tablas solo se deben utilizar para tabular datos y mostrarlos al usuario. Los diseños y maquetación de una página web se deben realizar con otras técnicas como hojas de estilo CSS.

## Tablas generadas a partir de datos externos.

En ocasiones, no podremos controlar cada aspecto de la relación entre nuestras tablas. Esto es común en tablas generadas de forma dinámica o a partir de datos extraídos de una base de datos, entre otras fuentes.

En estos casos, la recomendación fundamental es emplear una combinación de técnicas que permitan la mayor accesibilidad posible a la tabla que estemos creando. Para ello, podemos utilizar un conjunto de técnicas, como las vistas descritas a lo largo de esta sección, junto con otras propias de las tecnologías que estemos empleando para generar dicha tabla.

En el siguiente ejemplo, simulamos una tabla de personajes de Los Simpsons generada a partir de datos provenientes de una referencia externa, ya sea una base de datos u otro medio que contenga los datos que necesitamos. Además de esto, la tabla incluye columnas de elementos de acción asociados a cada estudiante. Esto añade un nivel de complejidad adicional a la tabla, ya que los botones de acción son idénticos para todos los personajes.

### Ejemplo de tabla de datos generáda a partir de una base de datos

{{demo: TablaPersonajes}}

### Explicación

En la tabla anterior, cada nombre y su correspondiente dato provienen de una referencia externa. Utilizando la tecnología correspondiente al tipo de proyecto, se creó una tabla en la que se marcaron los encabezados mediante los atributos 'scope', para indicar la relación de los encabezados de columna. Esto se llevó a cabo mediante HTML.

La última columna se combinó utilizando 'colspan' y también se marcó su relación de encabezado con ambas columnas. Asimismo, como cada fila tiene un botón genérico asociado para editar o eliminar cada usuario, en el 'aria-label' de cada botón generado, se hizo referencia al nombre de la persona en la fila correspondiente.

En este caso, al ser creada mediante .net, cada &lt;td&gt; se generaba mediante @Persona.Nombre. Se utilizó esto también en el 'aria-label' de cada botón, quedando de la siguiente manera: aria-label="Editar @Persona.Nombre". De esta manera, si el nombre de una fila era, por ejemplo, "Juan", al interactuar con el botón de editar los datos de este usuario, el lector de pantalla leerá "Editar Juan".

Esto también se aplica a los botones de "Eliminar". De esta manera, sin importar el dato generado y sin conocer este o su cantidad, nos aseguramos de que, independientemente de la longitud de la tabla con sus datos, filas y columnas, el usuario pueda identificar con qué botón de qué usuario está interactuando.

Podríamos ir más allá y mejorar el atributo 'aria-label' especificándolo con el nombre y apellido generados. De esta manera, si hay dos personas con el mismo nombre, nos aseguramos de que la etiqueta del botón correspondiente haga referencia al nombre completo de la persona y no solo a su nombre.

NOTA: Sabemos que esta técnica quizá no sea aplicable en todos los casos ni en todos los proyectos que trabajen con tablas generadas a partir de datos externos al sitio. El ejemplo presentado aquí es simplemente una invitación a desarrollar soluciones que permitan transmitir la información tabulada de manera accesible para los usuarios que utilizan herramientas de apoyo como lectores de pantalla usando combinaciones de las técnicas vistas en este apartado y otros.

Con esta revisión detallada sobre el uso de tablas, cerramos este ciclo de republicaciones que formaron parte de mi proyecto original **#HablemosDeAccesibilidad**. Aunque este bloque de contenidos técnicos básicos llega a su fin, esto es, en realidad, solo el comienzo de este espacio. Mi objetivo con este blog personal es ir mucho más allá; por ello, de aquí en adelante, empezaré a compartir nuevo contenido, nuevas investigaciones, reflexiones filosóficas sobre la discapacidad y guías avanzadas de ingeniería de software accesible. Este es un compromiso continuo por transformar la web en un entorno donde la inclusión no sea una opción, sino un estándar fundamental.

Espero que les haya sido de utilidad y nos vemos en la próxima entrega donde hablaremos más sobre accesibilidad web. ¡Hasta la próxima miches!
