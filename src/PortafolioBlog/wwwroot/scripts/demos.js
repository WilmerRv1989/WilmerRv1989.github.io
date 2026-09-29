// Comportamiento de las demos del blog (bloques ```html demo en Contenido/Blog).
// Se registra una sola vez sobre el documento, así funciona en cualquier artículo aunque
// Blazor cambie de página sin recargar.
//
//   <button data-demo-alerta="Mensaje">…</button>
//   Al activarlo, muestra "Mensaje" en una región role="alert" justo después del botón
//   (o después del <dialog>, si el botón está dentro de uno: el diálogo se cierra y el mensaje debe verse).
(function () {
    function mostrarAlerta(boton) {
        const demo = boton.closest('.demo');
        demo.querySelectorAll('.demo-alerta').forEach(anterior => anterior.remove());

        const alerta = document.createElement('div');
        alerta.setAttribute('role', 'alert');
        alerta.className = 'demo-alerta mt-3';
        alerta.textContent = boton.dataset.demoAlerta;
        (boton.closest('dialog') || boton).insertAdjacentElement('afterend', alerta);
    }

    // Una demo nunca envía su formulario: recargaría la página. La validación nativa
    // (required, type="email"…) sí actúa antes, porque 'submit' solo llega si el formulario es válido.
    // Excepción: <form method="dialog"> no navega, solo cierra su <dialog>, y eso sí debe ocurrir.
    document.addEventListener('submit', evento => {
        if (!evento.target.closest('.demo')) return;
        if (evento.target.method !== 'dialog') evento.preventDefault();
        if (evento.submitter && evento.submitter.dataset.demoAlerta !== undefined) {
            mostrarAlerta(evento.submitter);
        }
    });

    document.addEventListener('click', evento => {
        const boton = evento.target.closest('[data-demo-alerta]');
        if (!boton || !boton.closest('.demo')) return;
        // Un botón de envío dentro de un formulario lo atiende 'submit', respetando la validación.
        if (boton.form && boton.type === 'submit') return;
        evento.preventDefault();
        mostrarAlerta(boton);
    });
})();
