var id = localStorage.getItem("object_name");
console.log("pojs: " + id);
$(document).ready(function () {
var tabel = document.getElementById('drugs')
var count = document.getElementById("drugs").rows.length; 
    

    var idTender = localStorage.getItem("object_name");
    var value1 = JSON.parse(idTender);
        

    phamracyName = $.ajax({
        url: "/api/Tender",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({})
    }).then(function (data) {
        for (i = 0; i < data.length; i++) {
            
            var result = idTender.substring(1, idTender.length - 1);
            
            if (data[i].id == result)
                {
                document.getElementById("tenderName").textContent = "" + data[i].entityDTO.name;
                
                }
            }
        
    });

});

var count = 0;
function addRow() {
  count++;
  document.getElementById("drugs").insertRow(-1)
                    .innerHTML += '<tr><td>Medication name:</td>'
                    + '<td> <input type="text"></td >'
                    +'<td>Quantity:</td>'
                    +'<td> <input type="text"></td >'
                    +'<td>Price:</td>'
                    +'<td> <input type="text"></td >'
                    + '<td><button class="delete" onclick="deleteRow(); return false;">Delete</button></td>'                
                    +'</tr>'; 
};

function deleteRow()
{  
  $('.drugs tbody').on('click', '.delete', function () {       
   var row = $(this).closest("tr");
   var rowIndex = row.index(); 
   $(this).closest('tr').remove();   
     
  });

  
        
};

var negativePrice = false;
var negativeQuant = false;
var empty = false;
function sendOffer() {
    var allMed = "";
    var allQuantity = "";
    var allPrice = "";
    var pharmacyName = document.getElementById("offers").rows[1].getElementsByTagName('input')[0].value;
    var phamracyEmail = document.getElementById("offers").rows[2].getElementsByTagName('input')[0].value;


    var table = document.getElementById('drugs'),
        rows = table.getElementsByTagName('tr'),
        i, j, cells, customerId;

    for (i = 0; i < rows.length; i++) {
        var medicationName = document.getElementById("drugs").rows[i].getElementsByTagName('input')[0].value;
        var quantity = document.getElementById("drugs").rows[i].getElementsByTagName('input')[1].value;
        var price = document.getElementById("drugs").rows[i].getElementsByTagName('input')[2].value;

        if (pharmacyName == "" || pharmacyEmail == "" || medicationName == "" || quantity == "" || price == "") {
            empty = true;
            break;
        }
        else
            empty = false;

        allMed += medicationName + ";";
        allQuantity += quantity + ";";
        allPrice += price + ";";

       

        if (price < 1) {

            negativePrice = true;
            break;
        } else
            negativePrice = false;

        if (quantity < 1) {
            negativeQuant = true;
            break
        }
        else
            negativeQuant = false;


        


    }
    allMed = allMed.slice(0, -1);
    allQuantity = allQuantity.slice(0, -1);
    allPrice = allPrice.slice(0, -1);

    if (empty) alert("Please fill all fields before submit!");
    else if (negativePrice) {
        alert("Please insert positive value for price!");
    }
    else if (negativeQuant)
    {
        alert("Please insert positive value for quantity")
    }
    else {
        $.ajax({
            url: "/api/PharmacyOffers",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({
                IdTender: id.substring(1, id.length - 1),
                PharmacyName: pharmacyName,
                PharmacyEmail: phamracyEmail,
                Medicationes: allMed,
                Quantity: allQuantity,
                Price: allPrice
            }),

            success: function (result) {
                alert("Successefully send offers!");
                localStorage.clear();
                document.location.href = "http://localhost:49544/home";

            },
            error: function (data, ajaxOptions, thrownError) {
                console.log('Error:', data);
                alert("Cant be send!");
                location.reload();
            }
        });

        localStorage.clear();
    }
    

    
}
   



