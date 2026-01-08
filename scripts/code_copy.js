window.clipboardFunctions = {
    addCopyButtons: function () {
        const codeBlocks = document.querySelectorAll('pre');

        codeBlocks.forEach((container) => {
            // Verificación para no duplicar el botón si ya existe
            if (container.querySelector('.btn-copy')) return;

            const button = document.createElement('button');
            button.className = 'btn-copy';
            button.type = 'button';
            button.ariaLabel = 'Copiar código al portapapeles';
            button.ariaLive = 'polite';
            button.innerText = 'Copiar';

            button.onclick = () => {
                const codeText = container.querySelector('code').innerText;
                navigator.clipboard.writeText(codeText).then(() => {
                    button.innerText = '¡Copiado!';
                    button.classList.add('btn-copy-success');

                    // Revertimos el estado después de 2 segundos
                    setTimeout(() => {
                        button.innerText = 'Copiar';
                        button.classList.remove('btn-copy-success');
                    }, 2000);
                });
            };

            container.style.position = 'relative';
            container.prepend(button);
        });
    }
};