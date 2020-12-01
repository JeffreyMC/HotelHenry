window.onload = function () {
    var pass = document.getElementById("pass");
    var pass2 = document.getElementById("repeatPass");

    pass.onchange = confirmarPass;
    pass2.onkeyup = confirmarPass;

    function confirmarPass() {
        pass2.setCustomValidity("");
        if (pass.value != pass2.value) {
            pass2.setCustomValidity("Las contraseñas no coinciden");
        }
    }

    
}