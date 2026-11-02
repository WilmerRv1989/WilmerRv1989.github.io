---
titulo: "Mis complementos para NVDA: ajedrez, sudoku y crucigramas accesibles"
resumen: "Los complementos que desarrollo para el lector de pantalla NVDA: qué hace cada uno, cómo instalarlos y sus novedades. Una entrada que voy actualizando."
fecha: 2026-11-01
categoria: "Proyectos"
etiquetas: ["NVDA", "Complementos", "Juegos accesibles", "Lectores de pantalla"]
---

**Última actualización:** 1 de noviembre de 2026. Al final encontrarán el historial de cambios de esta entrada.

Hola gente, hoy les traigo una entrada un poco especial, porque no va a quedarse quieta. Aquí voy a reunir todos los complementos que desarrollo para el lector de pantalla NVDA, y la iré actualizando cada vez que publique uno nuevo o saque una versión con cambios importantes. Así no tienen que andar buscando entrada por entrada: si quieren saber qué hay y qué hay de nuevo, este es el lugar.

Por ahora son tres juegos: ajedrez, sudoku y crucigramas. Y sí, ya sé lo que algunos estarán pensando: ¿juegos? ¿No era este un blog sobre accesibilidad y desarrollo? Pues justamente por eso.

## ¿Por qué juegos?

Seamos sinceros: el ocio también es un derecho, y es de los primeros que se nos niegan. Los juegos de mesa clásicos, los pasatiempos del periódico y la mayoría de los juegos digitales dan por hecho que quien juega puede ver. Para quienes usamos lectores de pantalla, jugar una partida de ajedrez o resolver un crucigrama casi siempre significa depender de otra persona o conformarse con una versión a medias.

Además, estos juegos ejercitan cosas que me importan mucho: la concentración, la memoria, la atención, el pensamiento lógico. Y hay algo que los tres tienen en común y que para mí es su sello: **todos enseñan a jugar desde cero**, con un curso guiado, lenguaje sencillo y pasos cortos. Los pensé también para la infancia, porque un niño o una niña ciega que aprende ajedrez, sudoku o crucigramas no debería necesitar que alguien le describa el tablero en cada jugada.
## ¿Qué es un complemento de NVDA y cómo se instala?

Un complemento es un pequeño programa que se instala dentro de NVDA y le agrega funciones nuevas. Los míos se instalan desde la Tienda de complementos de NVDA, sin descargar nada a mano:

1. Abran el menú de NVDA con **NVDA+N**.
2. Vayan a **Herramientas** y luego a **Tienda de complementos**.
3. En la pestaña de complementos disponibles, busquen el nombre del juego (por ejemplo, «MiAjedrezAccesible»).
4. Elijan **Instalar** y reinicien NVDA cuando se los pida.

Cada complemento trae su propio manual en español.

## MiAjedrezAccesible

Ajedrez completo para NVDA. Se puede jugar contra el motor Stockfish con 10 niveles, y los más bajos están pensados para dejar ganar a quien empieza, porque nadie aprende a jugar perdiendo todas las partidas. Trae el curso **«Aprender a jugar»**, con 23 lecciones y 113 ejercicios, 5.000 problemas de Lichess con un nivel tipo Elo que se ajusta a ustedes, reloj, partidas en formato PGN y estadísticas.

Lo escribí desde cero, tomando como referencia el complemento Chessmart, que quedó abandonado en 2022 y ya no funciona en las versiones actuales de NVDA.

**Lo más reciente (versión 1.1.0):** el curso ya está también en inglés. Fue una petición de una persona de Indonesia que lo estaba usando y me escribió para pedirlo.

**Lo que viene:** también me pidieron traducirlo al portugués de Brasil, y es algo que estará pronto.

- [Página del proyecto en GitHub](https://github.com/WilmerRv1989/MiAjedrezAccesible)

## MiSudokuAccesible

Sudoku para NVDA y para todas las edades. Tiene tableros de 9×9 y miniaturas de 4×4 y 6×6 para empezar con calma. Las pistas no les dan la respuesta: les explican la técnica que pueden usar para encontrarla, que al final es lo que hace que uno mejore. También trae un curso de 13 lecciones y un sudoku del día con racha y estadísticas.

Siempre quise jugar sudoku para ejercitar la concentración y la atención. Así que, como con todo lo demás, lo hice.

**Lo más reciente (versión 1.0.0):** primera versión pública, disponible en la Tienda de complementos.

**Lo que viene:** igual que con el ajedrez, me pidieron traducirlo al portugués de Brasil, y también estará pronto.

- [Página del proyecto en GitHub](https://github.com/WilmerRv1989/MiSudokuAccesible)

## MiCrucigramaAccesible

Crucigramas en español pensados desde el inicio para lectores de pantalla. Cuando lo investigué no encontré ninguno así, y entendí por qué: un crucigrama no es solo leer pistas. Lo difícil es entender **cómo se cruzan las palabras**. Por eso el tablero se recorre «por caminitos», palabra por palabra, pensado para que en todo momento se entienda cómo se cruzan.

Tiene pistas graduadas, crucigramas infantiles, un curso guiado y un crucigrama del día. Las palabras vienen del Wikcionario, con licencia CC BY-SA, y las pistas infantiles las escribí yo.

**Lo más reciente (versión 1.0.0):** primera versión pública, disponible en la Tienda de complementos.

- [Página del proyecto en GitHub](https://github.com/WilmerRv1989/MiCrucigramaAccesible)

## ¿Cómo los hice?

Los tres los desarrollé con la asistencia de Claude, un modelo de inteligencia artificial de Anthropic. Claude escribió la mayor parte del código siguiendo mis indicaciones; yo diseñé cada juego, decidí cómo se comporta con el lector de pantalla, qué teclas usa y cómo se anuncia cada cosa, y probé cada función con NVDA. Cada manual tiene una sección que lo cuenta con detalle, y el código de los tres es libre, con licencia GPL.

## ¿Encontraron un error o tienen una idea?

Escríbanme a contacto@wilmer-rv.com o abran un reporte en la página de GitHub del complemento. Cada mensaje me ayuda a mejorarlos, y como ya les conté con el ajedrez, a veces de un mensaje sale una versión nueva.

Y aquí les voy a ser muy sincero: recibir esos mensajes, y descubrir que personas que nunca esperé, de lugares en los que ni siquiera pensé, quieren usar mis complementos, me hace sumamente feliz. Primero el curso en inglés, ahora el portugués de Brasil… Ese tipo de mensajes son los que más me animan a seguir.

Espero que los disfruten tanto como yo disfruté haciéndolos, y que los compartan con quien le puedan servir, sobre todo con niños y niñas que estén aprendiendo. Nos vemos en la próxima actualización de esta entrada. ¡Hasta la próxima, miches!

## Historial de cambios de esta entrada

- **1 de noviembre de 2026:** primera versión de la entrada, con MiAjedrezAccesible 1.1.0, MiSudokuAccesible 1.0.0 y MiCrucigramaAccesible 1.0.0.
