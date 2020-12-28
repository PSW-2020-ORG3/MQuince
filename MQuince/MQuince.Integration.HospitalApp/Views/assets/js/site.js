const uri = 'http://localhost:49544/api/Pharmacy'
let todos = [];

function addItem() {
    const apiKey = document.getElementById('apiKey');
    const name = document.getElementById('name');
    const url = document.getElementById('url');

    const item = {
        isComplete: false,
        apiKey: apiKey.value,
        name: name.value,        
        url: url.value
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
            apiKey.value = '';
            name.value = '';
            url.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));


} 