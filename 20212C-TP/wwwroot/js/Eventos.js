document.addEventListener("DOMContentLoaded", function (event) {

    var boton = document.getElementById('boton');
    var input = document.getElementById('idRecetas');
    var checks = document.querySelectorAll('.valores');

    boton.addEventListener('click', function () {
        input.value = '';
        checks.forEach((e) => {
            if (e.checked == true) {
                input.value = e.value + ',' + input.value;

            }

        })
    });

});