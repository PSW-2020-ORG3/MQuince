const uri = '/api/Tender'

function sendName() {
    const name = document.getElementById('name');
    const descritpion = document.getElementById('descritpion');
    const formLink = document.getElementById('formLink');
    const startDate = document.getElementById('startDate');
    const endDate = document.getElementById('endDate');

    if (name.value == "" || descritpion.value == "" || formLink.value == "" || startDate.value == "" || endDate.value == "") {

        alert("You need to fill all fields!");
    } else {
        alert("Tender successfully create!");
    }

    
    const item = {
        name: name.value,
        descritpion: descritpion.value,
        startDate: startDate.value,
        endDate: endDate.value,
        formLink: formLink.value,
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
            descritpion.value = '';
            startDate.value = '';
            endDate.value = '';
            formLink.value = '';

        })
        .catch(error => console.error('Unable to add item.', error));
} 

function parse(datum) {
    const d = new Date(datum)
    return new Date(d.getTime() - d.getTimezoneOffset() * 60 * 1000).toISOString().split('T')[0]
}