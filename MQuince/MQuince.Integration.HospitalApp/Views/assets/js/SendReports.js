const uri = '/api/sftpController'

function postDate() {
    const from = document.getElementById('from');
    const to = document.getElementById('to');

    const item = {
        from: from.value,
        to: to.value
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
            from.value = '';
            to.value = '';
            
        })
        .catch(error => console.error('Unable to add item.', error));


} 

