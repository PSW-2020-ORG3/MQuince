const uri = 'http://localhost:49544/api/urgentMessage'

function sendMedicationName() {
    const name = document.getElementById('name');
    const quantity = document.getElementById('quantity');

    const item = {
        name: name.value,
        quantity=quantity.value
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
