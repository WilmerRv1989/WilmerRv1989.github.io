window.accessibilityFunctions = {
    focusElement: function (id) {
        const element = document.getElementById(id);
        if (element) {
            // Hacemos que el elemento sea enfocable por script sin afectar el orden del TAB
            element.setAttribute('tabindex', '-1');
            element.focus();
        }
    }
};