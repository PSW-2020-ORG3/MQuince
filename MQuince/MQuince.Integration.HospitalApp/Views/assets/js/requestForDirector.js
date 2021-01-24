const uri = '/api/Grpc'
function sendName() {
    const name = document.getElementById('name');

    if (name.value == "" ) {

        alert("You need to fill all fields!");
    } else if (name.value != "" ) {
        alert("Medication sucesfully sent to the pharmacy!");
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

        })
        .catch(error => console.error('Unable to add item.', error));


} 
