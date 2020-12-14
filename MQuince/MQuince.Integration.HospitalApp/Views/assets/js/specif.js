/*const uri = 'http://localhost:8083/api/sftpController'

function sendName() {
    const name = document.getElementById('name');
   
    const item = {
        name: name.value
    };
    fetch(uri, {
        method: 'POST',
        mode: 'no-cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': 'http://localhost:8083',
            'Access-Control-Allow-Credentials':'true',
            'Access-Control-Allow-Methods' : 'POST'
        },
        body: JSON.stringify(item)       
    })
        .then(response => response.json())
        .then(() => {
            name.value = '';
            
        })
        .catch(error => console.error('Unable to add item.', error));


} */
$(document).ready(function () {
    $("#send").click(function () {
        var medication = new Object();
         medication.name = $('#name').val();        

        $.post('http://localhost:8083/api/sftpController', medication, function (data) {
            
        });

        $.post('http://localhost:49544/api/sftpController/rebexCall', medication, function (data) {
            console.log(data);
        });
           
        
    });
}); 