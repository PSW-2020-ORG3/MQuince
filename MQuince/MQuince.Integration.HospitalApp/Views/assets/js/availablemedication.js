const uri = 'api/GrpcController'

function sendName() {
    setInterval(function () {
        cache_clear()
    }, 5000);
    const name = document.getElementById('name'); 
    const quantity = document.getElementById('quantity');


    const item = {
        name: name.value,
        quantity: quantity.value
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
            quantity.value = '';

        })
        .catch(error => console.error('Unable to add item.', error));
} 
function cache_clear() {
    window.location.reload(true);
}

