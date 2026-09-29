---
titulo: "Uso de formularios accesibles"
encabezado: "Hablemos de Uso de formularios"
resumen: "Ejemplos interactivos sobre el etiquetado correcto de campos de formularios accesibles para lectores de pantalla."
fecha: 2026-01-10 10:00
categoria: "Accesibilidad web"
etiquetas: ["Formularios", "Interactivo", "html", "Accesibilidad"]
---

Nota: Esta es la cuarta entrada de una serie dedicada a la accesibilidad web. En esta serie, exploraremos diversos aspectos clave para garantizar que las páginas web sean accesibles para todos los usuarios, incluyendo aquellos con discapacidades. En esta entrada hablaremos del uso de formularios y su correcto etiquetado para la accesibilidad. Esta serie es una re-publicación de contenido que había creado anteriormente en un sitio web dedicado a la accesibilidad, con fines prácticos y educativos que ahora estoy trasladando a este blog personal para llegar a una audiencia más amplia interesada en el tema.

El uso de formularios para que los usuarios ingresen información o realicen búsquedas es común en las páginas web. Por esta razón, es importante que estos formularios sean accesibles y compatibles con las herramientas de apoyo utilizadas por personas con discapacidad.

Una recomendación clave es proporcionar etiquetas para identificar todos los controles del formulario, como campos de texto, casillas de verificación, botones de opción y menús desplegables. En la mayoría de los casos, garantizar que los formularios cumplan con los criterios de accesibilidad implica establecer las etiquetas correspondientes utilizando el elemento "label" del formulario.

Las etiquetas de un formulario deben describir en todos los casos el propósito y la función del campo correspondiente. Esto se logra asociando las etiquetas del formulario con los controles de formulario adecuados.

## Etiquetar correctamente un control de formulario

La asociación entre una etiqueta de formulario y su control puede ser implícita o explícita. Se recomienda que, siempre que sea posible, se realice de forma explícita.

Para asociar explícitamente una etiqueta con su control correspondiente, se utilizan los atributos 'for' e 'id', los cuales deben coincidir de manera idéntica para que la etiqueta del formulario y el control se relacionen correctamente. A continuación se muestra un ejemplo:

### Ejemplo 1:

```html demo sin-estilos
<div>
    <label for="correo" class="form-label">Correo electrónico:</label>
    <input type="email" class="form-control-lg" id="correo">
</div>
<div class="mt-2">
    <input type="checkbox" class="form-check-input" id="suscribirse">
    <label for="suscribirse" class="form-check-label">Suscribirse al boletín</label>
</div>
<div class="mt-3">
    <button type="submit" class="btn btn-outline-light" data-demo-alerta="Gracias por suscribirse al lado oscuro. Pronto recibirás nuestro boletín del Imperio Galáctico">Suscribirse</button>
</div>
```

### Explicación

En este ejemplo, se utilizan los atributos 'for' e 'id' para asociar la etiqueta y el campo de formulario. En el primer caso, se emplea 'correo' tanto en el 'for' como en el 'id' para que las herramientas de asistencia puedan leer la etiqueta al interactuar con el campo de formulario. Lo mismo ocurre con el uso de la casilla de verificación, donde se utiliza 'suscribirse' para asociar correctamente ambos elementos.

NOTA: Los nombres utilizados en los atributos 'for' e 'id' deben ser únicos para cada elemento de formulario. Si usamos el mismo nombre en dos casos distintos, causaremos confusión, ya que la herramienta de asistencia no sabrá a qué campo pertenece cada etiqueta.

## Ocultar la etiqueta del campo de formulario

En algunas situaciones, es apropiado ocultar visualmente la etiqueta de un campo de formulario, siempre y cuando su uso contextual sea suficiente para entender la función del campo. Esto es común en casos como los cuadros de búsqueda acompañados del botón "Buscar", entre otros.

Sin embargo, es importante mantener la etiqueta presente en el código HTML para que sea detectada por las herramientas de apoyo utilizadas por personas con discapacidad.

El siguiente ejemplo muestra el campo de búsqueda junto al botón de “Buscar”; el mismo tiene visualmente oculta la etiqueta del cuadro de formulario, pero esta sigue estando presente para las herramientas de apoyo.

### Ejemplo 2

```html demo
<label for="buscar" class="visually-hidden">Buscar:</label>
<input type="search" id="buscar">
<button type="submit" data-demo-alerta="No se ha encontrado ningún resultado">Buscar</button>
```

### Explicación

En este ejemplo, se continúa utilizando los atributos 'for' e 'id' para asociar la etiqueta con el campo de formulario. Sin embargo, en este caso, se oculta la etiqueta usando CSS, de modo que aunque esté visualmente oculta, sigue siendo accesible para las herramientas de apoyo.

## Uso de aria-label

El atributo aria-label se utiliza para etiquetar un control cuyo texto de referencia no es visible, pero está disponible para las herramientas de apoyo. Se recomienda su uso únicamente en casos donde el control de formulario se explique contextualmente, como se muestra en el siguiente ejemplo.

### Ejemplo 3:

```html demo sin-estilos
<input type="search" class="form-control-sm" aria-label="buscar">
<button type="submit" class="btn btn-outline-light" data-demo-alerta="Sigue sin haber ningún resultado">Buscar</button>
```

### Explicación

En este caso, el atributo aria-label contiene un texto que permite identificar el uso del control para usuarios de herramientas de apoyo. Este atributo sirve para describir la funcionalidad del control cuando no hay un texto circundante que lo explique o si este no es suficiente para que el usuario comprenda su funcionalidad por sí mismo.

## Uso de aria-labelledby

El atributo aria-labelledby se emplea para vincular un control de formulario con otro elemento cercano que pueda describir su función o propósito. A diferencia del atributo aria-label, que proporciona una etiqueta directamente, el aria-labelledby requiere que identifiquemos un elemento adicional mediante su ID para establecer esta asociación.

### Ejemplo 4:

```html demo sin-estilos
<input type="search" class="form-control-sm" aria-labelledby="botonbuscar">
<button id="botonbuscar" class="btn btn-outline-light" type="submit" data-demo-alerta="No sé qué esperas, sigue sin haber resultados">Buscar</button>
```

### Explicación

Cuando usamos el atributo aria-labelledby, estamos vinculando el control del formulario con la etiqueta o texto de otro elemento que tenga un ID de referencia. Una forma útil de entender la diferencia entre aria-labelledby y aria-label es que, en el primer caso, las herramientas de apoyo como lectores de pantalla leerán el texto de la etiqueta asociada, por ejemplo, el texto del botón "Buscar". Mientras que en el aria-label, el lector de pantalla leerá el texto que hayamos especificado directamente en el atributo.

## Formularios agrupados

HTML nos ofrece el elemento &lt;fieldset&gt;, el cual sirve para agrupar controles de formulario, los cuales serán relacionados con el título o leyenda que identifique la agrupación. Esta debe ser usada en aquellos casos donde se apliquen formularios asociados a datos específicos, elección de opciones excluyentes entre sí y otros casos similares. Veamos algunos ejemplos prácticos y su correcto uso.

### Ejemplo de formularios agrupados

```html demo sin-estilos
<div style="display: flex;">
  <form style="margin-right: 20px;">
    <fieldset>
      <legend>Dirección de Envío</legend>
      <div>
        <label for="nombre" class="form-label">Nombre:</label>
        <input type="text" class="form-control" id="nombre">
      </div>
      <div>
        <label for="pais" class="form-label">País:</label>
        <input type="text" class="form-control" id="pais">
      </div>
      <div>
        <label for="ciudad" class="form-label">Ciudad:</label>
        <input type="text" class="form-control" id="ciudad">
      </div>
      <div>
        <label for="calle" class="form-label">Calle:</label>
        <input type="text" class="form-control" id="calle">
      </div>
      <div>
        <label for="codigopostal" class="form-label">Código Postal:</label>
        <input type="text" class="form-control" id="codigopostal">
      </div>
    </fieldset>
  </form>

  <form>
    <fieldset>
      <legend>Dirección de Facturación</legend>
      <div>
        <label for="nombrefacturacion" class="form-label">Nombre:</label>
        <input type="text" class="form-control" id="nombrefacturacion">
      </div>
      <div>
        <label for="paisfacturacion" class="form-label">País:</label>
        <input type="text" class="form-control" id="paisfacturacion">
      </div>
      <div>
        <label for="ciudadfacturacion" class="form-label">Ciudad:</label>
        <input type="text" class="form-control" id="ciudadfacturacion">
      </div>
      <div>
        <label for="callefacturacion" class="form-label">Calle:</label>
        <input type="text" class="form-control" id="callefacturacion">
      </div>
      <div>
        <label for="codigopostalfacturacion" class="form-label">Código Postal:</label>
        <input type="text" class="form-control" id="codigopostalfacturacion">
      </div>
    </fieldset>
  </form>
</div>
<div class="mt-3">
  <button id="enviarpedido" class="btn btn-outline-light" type="submit" data-demo-alerta="¡Excelente! Pronto recibirás tu envío… Es broma, no vas a recibir nada.">Enviar formulario</button>
</div>
```

### Explicación

El elemento &lt;fieldset&gt; en este caso funciona como un contenedor que agrupa todos los campos de formulario relacionados con la dirección de envío o facturación. El título dentro del &lt;legend&gt; marca el grupo y será leído por las herramientas de apoyo una vez que el foco interactúe con alguno de los campos dentro de la agrupación, ya sea de facturación o envío.

Es importante tener en cuenta que, dependiendo de la configuración, los lectores de pantalla leerán la leyenda junto con cada campo de formulario. Por esta razón, se recomienda usar leyendas lo más cortas y concisas posible, y utilizar etiquetas claras para aquellos casos donde la leyenda solo se lea una vez.

### Ejemplo de agrupación usando radio buttons.

```html demo sin-estilos
<form>
    <fieldset>
        <legend>Seleccione la comida que le gustaría recibir:</legend>
        <div class="form-check">
            <input type="radio" class="form-check-input" name="radiogrupo" id="pizza" value="pizza">
            <label for="pizza" class="form-check-label">Pizza</label>
        </div>
        <div class="form-check">
            <input type="radio" class="form-check-input" name="radiogrupo" id="hamburguesa" value="hamburguesa">
            <label for="hamburguesa" class="form-check-label">Hamburguesa</label>
        </div>
        <div class="form-check">
            <input type="radio" class="form-check-input" name="radiogrupo" id="sushi" value="sushi">
            <label for="sushi" class="form-check-label">Sushi</label>
        </div>
    </fieldset>
</form>
<div class="mt-3">
    <button id="hacerpedido" class="btn btn-outline-light" type="submit" data-demo-alerta="Yo que usted espero sentado su pedido">Hacer pedido</button>
</div>
```

### Ejemplo de agrupación con casillas de verificación

```html demo sin-estilos
<form>
    <fieldset>
        <legend>Seleccione el formato de descarga de su cuento favorito:</legend>
        <div class="form-check">
            <input type="checkbox" class="form-check-input" id="formato1" value="txt">
            <label for="formato1" class="form-check-label">Formato EPUB</label>
        </div>
        <div class="form-check">
            <input type="checkbox" class="form-check-input" id="formato2" value="csv">
            <label for="formato2" class="form-check-label">Formato DOCX</label>
        </div>
        <div class="form-check">
            <input type="checkbox" class="form-check-input" id="formato3" value="json">
            <label for="formato3" class="form-check-label">Formato PDF</label>
        </div>
    </fieldset>
</form>
<div class="mt-3">
    <button id="descargar" class="btn btn-outline-light" type="submit" data-demo-alerta="Descargando... ¡Ups! Ha ocurrido un error en la descarga. Mejor suerte para la próxima">Iniciar descarga</button>
</div>
```

## Marcado de controles de formulario (placeholder)

Una forma de agregar ayuda contextual es mediante el uso del atributo 'placeholder' en los campos de formulario donde el usuario debe ingresar información. Este atributo proporciona texto de marcador de posición que ofrece orientación al usuario sobre el tipo de información que se espera en el campo.

El texto del marcador de posición se muestra visualmente dentro del campo de formulario y desaparece automáticamente una vez que el usuario comienza a escribir en él. Sin embargo, es importante tener en cuenta que una vez que el usuario empieza a ingresar información, el texto de marcador de posición ya no es visible. Por lo tanto, se debe proporcionar una orientación clara y concisa sobre el formato requerido en las etiquetas para evitar confusiones o errores por parte del usuario.

### Ejemplo uso de 'placeholder'

```html demo sin-estilos
<div class="col-5">
    <form>
        <fieldset>
            <legend>Ejemplo de formulario de Contacto</legend>

            <label for="nombrecontacto" class="form-label">Nombre:</label>
            <input type="text" class="form-control" id="nombrecontacto" placeholder="Ingrese su nombre">

            <label for="emailcontacto" class="form-label">Correo electrónico:</label>
            <input type="email" class="form-control" id="emailcontacto" placeholder="Ingrese su correo electrónico">

            <label for="mensajecontacto" class="form-label">Mensaje:</label>
            <textarea id="mensajecontacto" class="form-control" rows="3" placeholder="Escriba su mensaje aquí"></textarea>
        </fieldset>
    </form>
    <div class="mt-3">
        <button id="contactar" class="btn btn-outline-light" type="submit" data-demo-alerta="Hemos recibido tu mensaje, pronto serás contactado. Si quieres, puedes esperar sentado de nuevo como con tu comida favorita">Enviar mensaje</button>
    </div>
</div>
```

## Ejemplo de Formulario HTML5

HTML5 introdujo una variedad de tipos de entrada específicos más allá del simple campo de texto. Estos tipos semánticos, como email, tel, date o number, permiten describir con mayor precisión el tipo de dato que el usuario debe ingresar en un campo de formulario. Su uso es una práctica recomendada en accesibilidad, ya que proporciona información valiosa tanto para los navegadores como para las tecnologías de asistencia.

Al utilizar el tipo de input adecuado, los navegadores pueden optimizar la experiencia del usuario, por ejemplo, mostrando teclados específicos en dispositivos móviles para facilitar la entrada de correos electrónicos o números de teléfono. Para los usuarios de lectores de pantalla, estos tipos semánticos ofrecen un contexto adicional sobre el campo, ayudándoles a comprender qué tipo de información se espera y cómo interactuar con ella.

```html demo sin-estilos
<form>

    <div class="mt-2">
        <label for="campoTexto">Campo de Texto (text):</label>
        <input type="text" id="campoTexto" placeholder="Escribe algo aquí" required>
    </div>

    <div class="mt-2">
        <label for="campoContrasena">Contraseña (password):</label>
        <input type="password" id="campoContrasena" placeholder="Crear contraseña" required>
    </div>

    <div class="mt-2">
        <label for="areaTexto">Área de Texto (textarea):</label>
        <textarea id="areaTexto" rows="5" placeholder="Escribe algo extenso"></textarea>
    </div>

    <div class="mt-2">
        <label for="listaSeleccion">Lista de Selección (select):</label>
        <select id="listaSeleccion">
            <option value="">Selecciona una opción</option>
            <option value="opcion1">Opción Uno (Valor 1)</option>
            <option value="opcion2">Opción Dos (Valor 2)</option>
            <option value="opcion3">Opción Tres (Valor 3)</option>
        </select>
    </div>

    <div class="mt-2">
        <input type="checkbox" id="casillaVerificacion">
        <label for="casillaVerificacion">Casilla de Verificación (checkbox)</label>
    </div>

    <div class="mt-2">
        <fieldset>
            <legend>Botones de Radio (radio):</legend>
            <span>
                <input type="radio" id="radioOpcion1" name="radioOpciones" value="radioOpcion1">
                <label for="radioOpcion1">Seleccionar Radio Opción 1</label>
            </span>
            <span>
                <input type="radio" id="radioOpcion2" name="radioOpciones" value="radioOpcion2" checked>
                <label for="radioOpcion2">Seleccionar Radio Opción 2</label>
            </span>
            <span>
                <input type="radio" id="radioOpcion3" name="radioOpciones" value="radioOpcion3">
                <label for="radioOpcion3">Seleccionar Radio Opción 3</label>
            </span>
        </fieldset>
    </div>

    <div class="mt-2">
        <label for="campoEmail">Correo Electrónico (email):</label>
        <input type="email" id="campoEmail" placeholder="ejemplo@dominio.com">
    </div>

    <div class="mt-2">
        <label for="campoURL">URL (url):</label>
        <input type="url" id="campoURL" placeholder="https://www.hablemos-de-accesibilidad.com">
    </div>

    <div class="mt-2">
        <label for="campoTelefono">Teléfono (tel):</label>
        <input type="tel" id="campoTelefono" placeholder="Ej: +(506)-1234-4567">
    </div>

    <div class="mt-2">
        <label for="campoBusqueda">Búsqueda (search):</label>
        <input type="search" id="campoBusqueda" placeholder="Escribe tu búsqueda...">
    </div>

    <div class="mt-2">
        <label for="rangoDeslizante">Rango Deslizante (range):</label>
        <input type="range" id="rangoDeslizante" min="0" max="100" step="1" value="50">
    </div>

    <div class="mt-2">
        <label for="campoNumero">Número (number):</label>
        <input type="number" id="campoNumero" min="0" max="10" step="1" value="5">
    </div>

    <div class="mt-2">
        <label for="campoFecha">Fecha (date):</label>
        <input type="date" id="campoFecha">
    </div>

    <div class="mt-2">
        <label for="campoMes">Mes (month):</label>
        <input type="month" id="campoMes">
    </div>

    <div class="mt-2">
        <label for="campoSemana">Semana (week):</label>
        <input type="week" id="campoSemana">
    </div>

    <div class="mt-2">
        <label for="campoHora">Hora (time):</label>
        <input type="time" id="campoHora">
    </div>

    <div class="mt-2">
        <label for="campoFechaHoraLocal">Fecha y Hora Local (datetime-local):</label>
        <input type="datetime-local" id="campoFechaHoraLocal">
    </div>

    <div class="mt-2">
        <label for="campoColor">Color (color):</label>
        <input type="color" id="campoColor" value="#008080">
    </div>

</form>
```

### <span class="bi bi-pencil" aria-hidden="true"></span> Anotaciones sobre Tipos de Campo de Entrada HTML5

Utilizar los tipos de campo de entrada semánticos de HTML5 es una buena práctica por varias razones. Mejoran la experiencia de usuario al ofrecer interfaces más intuitivas, como teclados especializados en dispositivos móviles para correos electrónicos o números. Además, proporcionan validación básica por parte del navegador, lo que ayuda a prevenir errores de entrada comunes. Para las tecnologías de asistencia, el tipo de campo es crucial, ya que les permite anunciar el propósito del campo y adaptar su interacción a las expectativas del usuario.

- **`type="email"`, `type="tel"`, `type="url"`:**

  Estos tipos van más allá de un simple campo de texto. En dispositivos móviles, activan teclados especializados que incluyen caracteres comunes para correos electrónicos, números para teléfonos o barras para URLs, agilizando la entrada de datos. Además, el navegador puede realizar una validación básica del formato, indicando al usuario si el valor ingresado no parece ser una dirección de correo, un número de teléfono o una URL válidos.

- **`type="date"`, `type="time"`, `type="month"`, `type="week"`, `type="datetime-local"`:**

  Al usar estos tipos, los navegadores suelen mostrar selectores de fecha y hora integrados, eliminando la necesidad de JavaScript personalizado o la posibilidad de errores de formato. Esto no solo mejora la usabilidad para todos, sino que garantiza que los usuarios de teclado o lectores de pantalla puedan seleccionar fechas y horas de manera consistente y sin ambigüedades.

- **`type="number"`, `type="range"`:**

  `type="number"` proporciona controles de incremento/decremento (spinners) y restringe la entrada a solo números, mientras que `type="range"` ofrece un deslizador intuitivo. Ambos tipos facilitan la entrada de valores numéricos, y para los usuarios de tecnologías de asistencia, el propósito numérico del campo es claramente comunicado. Con `type="range"`, el lector de pantalla informará que es un "deslizador" y a menudo su valor actual, lo que es esencial.

- **`type="search"`:**

  Aunque funcionalmente similar a un `type="text"`, el `type="search"` tiene una semántica específica que indica al navegador que el campo está diseñado para una búsqueda. Esto puede afectar cómo se muestra el campo (a menudo con un icono de lupa o una "x" para borrar el texto) y cómo los lectores de pantalla lo anuncian, proporcionando un contexto más claro al usuario.

- **`type="color"`:**

  Este tipo activa un selector de color nativo del navegador, lo que simplifica enormemente la elección de colores y asegura que la interacción sea consistente y accesible sin importar el dispositivo. Para un lector de pantalla, se anunciará como un "selector de color", dando al usuario la información necesaria.

Como hemos visto, la accesibilidad en los formularios no es solo una cuestión de cumplimiento técnico, sino de autonomía para el usuario. Implementar etiquetas claras y atributos semánticos correctamente asegura que cualquier persona, independientemente de la herramienta de asistencia que utilice, pueda completar sus tareas con éxito y sin barreras. Espero que estos ejemplos prácticos te sirvan de guía para construir interfaces más inclusivas.

Con esto concluimos el apartado sobre formularios. En la próxima y última entrega de esta serie, nos enfocaremos en un componente vital para la organización de información compleja: las tablas de datos accesibles. Exploraremos cómo estructurar correctamente los encabezados y las relaciones de datos para que la información tabular sea clara, lógica y navegable para todos los usuarios.

Espero que les haya sido de utilidad y nos vemos en la próxima entrega donde hablaremos más sobre accesibilidad web. ¡Hasta la próxima miches!
