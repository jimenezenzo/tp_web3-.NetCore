const uri = 'https://localhost:44301/api/Evento/cancelar';

function cancelarEvento(idEvento, idCocinero) {
    console.log('Evento a cancelar: ' + idEvento, 'Id de cocinero: ' + idCocinero)

    const item = {
        idEvento: idEvento,
        idCocinero: idCocinero
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
    .then(response => response.json())
    .then(response => {
        console.log(response)
    })
    .catch(error => console.error('Error al cancelar evento.', error));
}