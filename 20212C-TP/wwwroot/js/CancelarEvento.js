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
            if (error.response.status == 422) {
                ingresarAlerta(error.response.data.error)
                alertError.style.display = "block"
            }

            $('.modal').modal('hide');
        })
}

function ingresarAlerta(mensaje) {
    var alertMensaje = document.createElement("p")
    alertMensaje.textContent = mensaje

    alertError.appendChild(alertMensaje)
}