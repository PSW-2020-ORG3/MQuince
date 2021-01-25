const uri = '/api/Pharmacy'
let todos = [];



let exists = false;

function addItem() {

    const apiKey = document.getElementById('apiKey');
    const name = document.getElementById('name');
    const url = document.getElementById('url');

    if (apiKey.value == "" || name.value == "" || url.value == "") {

        alert("You need to fill all fields!");
    }
    else {

        $.ajax({
            url: "/api/Pharmacy",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            method: 'GET',
            data: JSON.stringify({})
        }).then(function (data) {
            
           for (i = 0; i < data.length; i++) {
                console.log("DA  " + data[i].entityDTO.apiKey);
                if (data[i].entityDTO.apiKey == apiKey.value) {
                    exists = true;
                    alert("Pharmacy with this API key have been already registered!");
                    break;
                }
                else
                    console.log("usao");
                    exists = false;
            }
            console.log("STA");
           
            if (exists == 0) {
                if (apiKey.value.length < 25) {
                    alert("Please be sure that you have the right api key that pharmacy gave you!");
                }
                else {

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
                            alert("Succesefully registered!");
                        })
                        .catch(error => console.error('Unable to add item.', error));
                }
                
            }
        });

        
       
        
    }

     


} 