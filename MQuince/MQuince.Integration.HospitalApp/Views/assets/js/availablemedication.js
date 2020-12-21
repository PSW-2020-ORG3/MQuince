const uri = 'http://localhost:49544/api/GrpcController'

function sendName() {
    const name = document.getElementById('name');

    const item = {
        name: name.value
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
        .then(() => {
            name.value = '';

        })
        .catch(error => console.error('Unable to add item.', error));
} 
