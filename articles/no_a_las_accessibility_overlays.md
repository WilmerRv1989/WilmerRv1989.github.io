# No a las Accessibility Overlays {#titulo-principal}

Hola gente, si, lo sé, la entrada un millón sobre lo mismo. Hoy quiero tocar un tema que puede levantar cejas, incomodar a más de uno en reuniones y, precisamente por eso, vale muchísimo la pena discutir con calma, porque sigue siendo una practica común, un canto de sirena que se niega a desaparecer a pesar de la abundante evidencia de su fracaso: las llamadas capas de accesibilidad, también conocidas como *accessibility overlays* o *widgets*.

Durante los últimos años, conforme crece la presión por cumplir con estándares de accesibilidad, evitar reclamos legales y mostrar compromiso con la inclusión digital, también ha crecido el mercado de las supuestas soluciones rápidas. Ya saben de cuáles hablo: ese botoncito flotante con un icono de persona, accesibilidad o silla de ruedas que aparece en una esquina y promete arreglarlo todo como por arte de magia.

Estas herramientas se venden como si fueran una salida elegante, rápida y barata para “cumplir con la accesibilidad”. Pero una cosa es que algo se venda bien y otra muy distinta es que realmente funcione, que respete a las personas usuarias y que resuelva el problema de fondo. Mi postura es clara: en la enorme mayoría de casos, estas capas no solo no arreglan la accesibilidad real, sino que pueden empeorarla, retrasar las correcciones necesarias y generar una peligrosa ilusión de cumplimiento.

Así que hoy quiero explicar qué son exactamente, por qué tanta gente en accesibilidad las cuestiona, por qué a muchas organizaciones les resultan tan seductoras y cuáles son los riesgos reales —técnicos, legales, operativos y hasta éticos— de intentar resolver con un script lo que solo se arregla diseñando, desarrollando y probando con criterio.

## ¿Qué son exactamente las capas de accesibilidad?

En términos simples, un *overlay* es un software de terceros que se monta por encima de un sitio web ya existente. Normalmente se integra con una sola línea de JavaScript, carga una interfaz adicional visible para la persona usuaria y promete ofrecer funciones como cambiar contraste, aumentar tipografía, pausar animaciones, resaltar enlaces, activar lectura en voz alta o incluso “reparar” problemas del HTML de forma automática.

Hasta aquí, leído rápido, puede sonar razonable. El problema es que muchas de estas herramientas no se limitan a ofrecer ajustes visuales; también intentan intervenir el DOM en tiempo de ejecución para inyectar atributos `aria`, generar textos alternativos, modificar etiquetas, alterar nombres accesibles o cambiar comportamientos de componentes interactivos. O sea: no arreglan el código fuente, sino que intentan ponerle encima una capa correctiva mientras la página ya está cargada.

## La promesa del "100% de cumplimiento con un solo clic"

La popularidad de estas herramientas no nació porque resolvieran bien el problema, sino porque supieron vender una promesa muy tentadora: “copie este script, active este widget y su sitio será accesible”. Algunas incluso van más allá y sugieren cumplimiento con WCAG, alineación normativa y reducción del riesgo legal casi inmediata.

Seamos sinceros: para una organización con poco conocimiento técnico, presupuesto limitado o temor a una demanda, ese discurso suena demasiado atractivo. Parece evitar auditorías, rediseños, correcciones de componentes, revisión de contenido, pruebas manuales, capacitación del equipo y todo ese trabajo que sí implica hacer accesibilidad en serio. El problema es que esa promesa parte de una simplificación engañosa.

La accesibilidad no es un efecto visual que se activa desde fuera. Es una propiedad de la estructura, del contenido, de la semántica, de la interacción, del orden de lectura, del enfoque, de los mensajes de error, del comportamiento dinámico y de la compatibilidad con tecnologías de apoyo. Y todo eso depende del diseño y del código real del sitio. Ninguna herramienta de terceros puede deducir con fiabilidad absoluta la intención comunicativa de una imagen para escribir un `alt` correcto, reconstruir la lógica de navegación de un formulario complejo mal diseñado o reparar desde afuera una jerarquía de encabezados inexistente.

## ¿Por qué seducen tanto a las organizaciones?

Porque prometen exactamente lo que muchos quieren escuchar: rapidez, bajo costo, apariencia de acción y tranquilidad. En vez de decir “hay que revisar plantillas, corregir formularios, rehacer componentes y probar con personas usuarias y tecnologías de apoyo”, dicen “instale esto y siga adelante”. En entornos donde la accesibilidad todavía se ve como gasto, como requisito incómodo o como problema jurídico, esa narrativa entra solita.

También seducen porque producen una ilusión muy administrable: un botón visible, un panel con opciones, reportes automáticos, puntajes vistosos y un proveedor que asegura acompañamiento. Todo eso luce bien en presentaciones, comités y reportes de cumplimiento. Pero que algo sea fácil de mostrar no significa que sea útil para quien realmente necesita acceder al contenido. Y aquí conviene decirlo sin rodeos: muchas veces se compran más para tranquilizar a la organización que para resolver la experiencia de las personas con discapacidad.

## ¿Por qué las capas de accesibilidad restan en lugar de sumar?

La crítica contra estas herramientas no nace del capricho ni de una guerra de bandos. Nace de la experiencia acumulada de personas usuarias, especialistas, desarrolladores, testers y organizaciones que llevan años viendo el mismo patrón: se instala la capa, se presume que el problema quedó resuelto, pero los obstáculos reales siguen ahí. El <a href="https://overlayfactsheet.com/es/" target="_blank" rel="noopener noreferrer">Overlay Factsheet</a>, respaldado por cientos de profesionales y personas con discapacidad, resume con claridad buena parte de estos problemas.

### 1. Interfieren con tecnologías de apoyo y con las preferencias reales del usuario

Este, para mí, es uno de los puntos más graves. Muchas personas que usamos lectores de pantalla, magnificadores, esquemas de alto contraste, ampliación, navegación por teclado o configuraciones específicas del sistema operativo ya tienen su entorno ajustado de acuerdo con sus necesidades. La persona usuaria no está esperando que un sitio le imponga otra capa de ajustes encima. Está esperando que el sitio respete su tecnología, su navegador, su configuración y su forma de navegar.

Cuando el overlay detecta un lector de pantalla e intenta “ayudar”, muchas veces lo que hace es duplicar anuncios, sobreescribir nombres accesibles, alterar el foco, introducir atajos extraños o romper la navegación esperada. La <a href="https://www.edf-feph.org/publications/joint-statement-on-accessibility-overlays/" target="_blank" rel="noopener noreferrer">declaración conjunta del European Disability Forum y la IAAP sobre accessibility overlays</a> advierte que estas herramientas pueden interferir con la tecnología de apoyo y no constituyen una alternativa aceptable a corregir el sitio.

Y aquí entran ejemplos muy concretos: botones que el lector de pantalla anuncia dos veces, menús flotantes que capturan el foco y no lo sueltan bien, controles del widget que ni siquiera son cómodos de usar con teclado, elementos que se tapan entre sí cuando se aumenta el texto o anuncios automáticos que interrumpen la lectura normal del contenido. O sea, terminan agregando ruido donde ya había suficientes barreras.

### 2. No corrigen la accesibilidad de fondo; apenas maquillan síntomas

Aquí está el corazón técnico del problema. Un overlay no reescribe la arquitectura real del sitio ni corrige el origen del error. Lo que hace, en el mejor de los casos, es modificar temporalmente el DOM del lado cliente. Eso significa que los cambios dependen de que el script cargue, de que funcione bien, de que no haya bloqueos y de que la intervención automática acierte. Si el script falla o se desactiva, desaparece la supuesta remediación y el sitio sigue teniendo el mismo problema estructural de siempre. Eso es justamente uno de los puntos centrales documentados por el <a href="https://overlayfactsheet.com/es/" target="_blank" rel="noopener noreferrer">Overlay Factsheet</a>.

Y hay cosas que sencillamente no se arreglan desde afuera: una jerarquía de encabezados rota, un formulario sin asociación correcta entre etiquetas y campos, una tabla de datos mal estructurada, un modal sin manejo correcto del foco, un carrusel imposible de pausar, mensajes de error que no se anuncian, enlaces con texto ambiguo, componentes personalizados sin semántica nativa o una secuencia de tabulación absurda. La accesibilidad no es solo “poner ARIA”; es preservar significado, relación, contexto y operabilidad real.

### 3. Introducen deuda técnica, dependencia y riesgo operativo

Otra cosa que rara vez se dice con suficiente claridad es que estas capas no solo fallan en resolver el problema, sino que además pueden retrasar las correcciones reales. Cuando una organización cree que “ya hizo accesibilidad” porque contrató un widget, baja la urgencia de revisar diseño, contenido, desarrollo y QA. Y así, lo que debía ser una mejora estructural termina convertido en deuda técnica con maquillaje encima.

Además, se crea una dependencia innecesaria de un proveedor externo. Si cambia el servicio, si sube el costo, si el script deja de cargar, si el proveedor desaparece o si la “corrección automática” entra en conflicto con un rediseño futuro, el equipo queda atado a una pieza externa que nunca debió convertirse en el centro de la estrategia de accesibilidad.

### 4. Son también un riesgo de privacidad, seguridad y rendimiento

No es un detalle menor que casi todas estas soluciones entren al sitio mediante JavaScript de terceros con capacidad para leer y modificar el DOM completo. Eso implica una cesión de control importante. La <a href="https://cheatsheetseries.owasp.org/cheatsheets/Third_Party_Javascript_Management_Cheat_Sheet.html" target="_blank" rel="noopener noreferrer">guía de OWASP sobre gestión de JavaScript de terceros</a> recuerda tres riesgos clave: pérdida de control sobre cambios en la aplicación cliente, ejecución de código arbitrario en los sistemas de las personas usuarias y posible fuga de información sensible hacia terceros.

A eso súmenle el impacto en rendimiento, la ampliación de la superficie de ataque, la dificultad de auditar realmente qué hace el script en cada sesión y la posibilidad de que recolecte o procese interacciones del usuario para alimentar análisis propios. Cuando hablamos de accesibilidad no podemos olvidarnos de otra cosa básica: una solución que introduce más riesgo técnico y más dependencia tampoco es una buena solución.

### 5. No ofrecen seguridad legal real y pueden agravar el problema

Este punto merece decirse sin rodeos: una capa de accesibilidad no equivale a conformidad con WCAG, no sustituye auditorías manuales, no reemplaza pruebas con personas usuarias y no convierte por sí sola un sitio inaccesible en uno accesible. La <a href="https://www.edf-feph.org/publications/joint-statement-on-accessibility-overlays/" target="_blank" rel="noopener noreferrer">declaración conjunta del European Disability Forum y la IAAP sobre accessibility overlays</a> es directa al afirmar que los overlays no garantizan cumplimiento con la legislación europea y no sustituyen la corrección del sitio.

De hecho, ahí está una de las trampas más peligrosas: confundir la compra de una herramienta con el cumplimiento de una obligación. Si el contenido sigue siendo inaccesible, el riesgo sigue existiendo. Y si además la herramienta añade barreras nuevas o genera una falsa sensación de tranquilidad, el problema no solo permanece: se vuelve más difícil de reconocer y de atacar a tiempo.

## Lo que una overlay no puede resolver, aunque el marketing diga lo contrario

No puede entender el propósito real de una imagen para redactar un texto alternativo con sentido. No puede decidir con criterio si un enlace es ambiguo o si un botón tiene un nombre accesible adecuado. No puede reconstruir desde afuera una arquitectura semántica coherente cuando el HTML de base está mal hecho. No puede garantizar que un flujo de compra, un formulario de matrícula o un sistema de pagos sea operable solo con teclado de principio a fin si los componentes fueron desarrollados sin contemplar accesibilidad desde el inicio.

Tampoco puede sustituir el juicio humano para evaluar si una instrucción se entiende, si una validación comunica bien el error, si una tabla expone correctamente sus relaciones o si un cambio dinámico se anuncia de manera útil. El problema de fondo es creer que accesibilidad es una lista de atributos. No. Accesibilidad es experiencia de uso, comprensión, operabilidad y compatibilidad real con diferentes formas de navegar.

## Entonces, ¿qué deberíamos hacer en lugar de instalar una overlay?

Primero, asumir algo básico pero liberador: la accesibilidad no se resuelve con un parche cosmético al final del proyecto. Se trabaja desde el diseño, el contenido, el desarrollo y las pruebas. Eso implica revisar semántica HTML, navegación por teclado, nombres accesibles, contraste, foco visible, estructura de encabezados, tablas, formularios, componentes dinámicos y mensajes de error. Implica también probar con tecnologías de apoyo reales y no depender únicamente de herramientas automáticas.

Segundo, entender que la automatización puede ayudar, pero no reemplazar el trabajo profesional. Los escáneres, validadores y chequeos automáticos sirven para detectar una parte del problema, priorizar hallazgos y acelerar revisiones, pero no sustituyen la evaluación manual ni la prueba con usuarios. En otras palabras: automatizar puede apoyar una estrategia de accesibilidad; no puede fingir ser la estrategia completa.

Tercero, formar criterio dentro del equipo. Si diseño, desarrollo, contenido, QA, compras y jefaturas entienden lo básico sobre accesibilidad, es mucho más difícil que una promesa milagrosa les venda humo. Y esto no es menor, porque muchas veces el problema no empieza con mala intención, sino con desconocimiento y prisa.

## En conclusión: la accesibilidad no se instala, se diseña

Adoptar una overlay parte de una idea equivocada: pensar que la accesibilidad es una capa superficial que se añade al final, cuando en realidad debería formar parte de la arquitectura misma del producto digital. Cuando esa lógica se instala en los equipos, lo que se deteriora no es solo la calidad técnica del sitio, sino también la forma en que se entiende la inclusión.

No existen atajos mágicos, ni herramientas de terceros milagrosas, ni widgets capaces de reemplazar el trabajo serio de diseñar, desarrollar, redactar y probar con conciencia. Si de verdad queremos sitios accesibles, tenemos que volver a lo esencial: HTML semántico, componentes bien construidos, contenido claro, pruebas reales con teclado y lectores de pantalla, y una cultura de mejora continua.

Así que no, la accesibilidad no se compra en forma de botoncito flotante. No se terceriza a una capa que intenta adivinar lo que el sitio debió hacer bien desde el principio. Y no se demuestra con una interfaz vistosa, sino con una experiencia realmente usable para las personas que dependen de ella.

Si esta entrada les sirve para cuestionar una compra apresurada, abrir una conversación más honesta en su equipo o defender la necesidad de corregir accesibilidad de raíz, ya habrá valido la pena escribirla. Porque al final, de eso se trata: de dejar de buscar parches vistosos y empezar a construir experiencias que de verdad incluyan.

Espero que esta reflexión les resulte útil, les dé mejores argumentos para debatir este tema y, sobre todo, les ayude a desconfiar un poco más de las soluciones que prometen accesibilidad instantánea sin tocar el problema real. ¡Hasta la próxima, miches!

Posdata: Si quieren profundizar en el tema les dejo algunas entradas útiles, que entre muchas otras, dejan patente el hecho de que estas soluciones de accesibilidad, de soluciones no tienen nada:
## Referencias
- <a href="https://overlayfactsheet.com/es/" target="_blank" rel="noopener noreferrer">Overlay Factsheet en español: análisis crítico sobre las capas de accesibilidad y sus limitaciones</a>
- <a href="https://accesibilidadweb.dlsi.ua.es/?menu=que-son-capas-accesibilidad-accessibility-overlays" target="_blank" rel="noopener noreferrer">Qué son las capas de accesibilidad o accessibility overlays: explicación y análisis en Accesibilidad Web</a>
- <a href="https://umarcomm.umn.edu/blog/2022/04/18/6-reasons-avoid-using-web-accessibility-overlays" target="_blank" rel="noopener noreferrer">Seis razones para evitar el uso de overlays de accesibilidad web, según UMN University Relations</a>
- <a href="https://www.hiberus.com/crecemos-contigo/overlays-de-accesibilidad/" target="_blank" rel="noopener noreferrer">Overlays de accesibilidad: reflexión crítica desde Hiberus</a>
- <a href="https://www.a11yproject.com/posts/should-i-use-an-accessibility-overlay/" target="_blank" rel="noopener noreferrer">¿Debería usar un accessibility overlay?: postura y recomendaciones de The A11Y Project</a>
- <a href="https://brickfield.ie/2026/03/27/why-accessibility-overlays-fail/" target="_blank" rel="noopener noreferrer">Por qué fallan los overlays de accesibilidad: artículo de Brickfield</a>
- <a href="https://www.siteimprove.com/glossary/accessibility-overlays/" target="_blank" rel="noopener noreferrer">Accessibility overlays: definición general y contexto desde Siteimprove</a>
- <a href="https://www.edf-feph.org/publications/joint-statement-on-accessibility-overlays/" target="_blank" rel="noopener noreferrer">Declaración conjunta sobre accessibility overlays del European Disability Forum y la IAAP</a>
- <a href="https://www.accessibilityassociation.org/overlay-position-and-recommendations" target="_blank" rel="noopener noreferrer">Postura y recomendaciones de la IAAP sobre overlays, plugins y widgets de accesibilidad</a>
- <a href="https://cheatsheetseries.owasp.org/cheatsheets/Third_Party_Javascript_Management_Cheat_Sheet.html" target="_blank" rel="noopener noreferrer">Guía de OWASP sobre la gestión de JavaScript de terceros y sus riesgos de seguridad</a>
