const uri = '/api/Grpc'

function sendName() {
    const name = document.getElementById('name');
    const quantity = document.getElementById('quantity');

    if (name.value == "" || quantity.value == "") {

        alert("You need to fill all fields!");
    } else if (quantity.value < 1) {
        alert("Quantity can't be negative!");
    } else if (name.value != "" || quantity.value != "") {
        alert("Medication sucesfully sent to the farmacy!");
    } 

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