const uri = 'https://localhost:44301/api/Evento/cancelar';

document.addEventListener('DOMContentLoaded', () => {
    var alertError = document.querySelector('#alertError')
    alertError.style.display = "none"
})

function cancelarEvento(idEvento, idCocinero) {
    alertError.style.display = "none"

    if (alertError.childNodes.length > 0) {
        alertError.removeChild(alertError.firstChild)
    }
    
    const item = {
        idEvento: idEvento,
        idCocinero: idCocinero
    };

    axios.post(uri, item)
        .then(response => {
            location.reload()
        })
        .catch(error => {
            if (error.response.status == 400) {
                console.log(alertError)
                var error = error.response.data.message

                var alertMensaje = document.createElement("p")
                alertMensaje.textContent = error

                alertError.appendChild(alertMensaje)

                alertError.style.display = "block"
            }
        })
}
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