﻿var tenderName = "";
var pharmacyEmail = "";
var idTender = "";
var offerID = "";

var tenders = $.ajax({
    url: "/api/Tender",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    type: "GET",
    data: JSON.stringify({})
});


$(document).ready(function () {

    $.ajax({
        url: "/api/PharmacyOffers",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        method: 'GET',
        data: JSON.stringify({})
    }).then(function (data) { 
        for (i = 0; i < data.length; i++) {
            var d = JSON.parse(tenders.responseText);

            for (j = 0; j < parseInt(d.length); j++) {
                console.log()
                if (d[j].id == data[i].entityDTO.idTender) {

                    offerID = data[i].id;
                    tenderName = d[j].entityDTO.name;
                    idTender = data[i].entityDTO.idTender;
                    pharmacyEmail = data[i].entityDTO.pharmacyEmail;
                    
                    
                    break;
                }
            }

            var div = document.createElement("div");
            div.id = "oneOffer";
            div.className = "oneOffer";

            var h2 = document.createElement("H2");
            var text = document.createTextNode("TENDER NAME: " + tenderName);
            h2.appendChild(text);
            div.appendChild(h2);

            var h2 = document.createElement("H2");
            var text = document.createTextNode("PHARMACY NAME: " + data[i].entityDTO.pharmacyName);
            h2.appendChild(text);
            div.appendChild(h2);
            
            var h2 = document.createElement("H2");
            var text = document.createTextNode("PHARMACY EMAIL: " + data[i].entityDTO.pharmacyEmail);

            
            h2.appendChild(text);
            div.appendChild(h2);
            var medicationes = "";
            var quantities = "";
            var prices = "";
           
           medicationes = (data[i].entityDTO.medicationes).split(";");
            quantities = (data[i].entityDTO.quantity).split(";");
            prices = (data[i].entityDTO.price).split(";");
           

            var table = document.createElement("table");
            table.id = "medTable";
            var thMed = document.createElement("th");
            thMed.textContent = "Medication";
            var thQua = document.createElement("th");
            thQua.textContent = "Quantity";
            var thPri = document.createElement("th");
            thPri.textContent = "Price";

            var tr = document.createElement("tr");
            
            tr.appendChild(thMed);
            tr.appendChild(thQua);
            tr.appendChild(thPri);
            table.appendChild(tr);

            if (medicationes.length==1)
            {
                var tr = document.createElement("tr");
                var td = document.createElement("td");

                td.textContent = medicationes;
                tr.appendChild(td);

                var td = document.createElement("td");
                td.textContent = quantities;
                tr.appendChild(td);

                var td = document.createElement("td");
                td.textContent = prices;
                tr.appendChild(td);

               
                table.appendChild(tr);
            }
            else {
             for (m = 0; m < medicationes.length; m++) {
                 var tr = document.createElement("tr");
                var td = document.createElement("td");

                td.textContent = medicationes[m];
                tr.appendChild(td);

                var td = document.createElement("td");
                td.textContent = quantities[m];
                tr.appendChild(td);

                var td = document.createElement("td");
                td.textContent = prices[m]+" $";
                tr.appendChild(td);
               
                table.appendChild(tr);
            }         
           
              
            } 

            div.appendChild(table);
            var button = document.createElement("button");
            var text = document.createTextNode("Approve");
            button.id = offerID;
            
            button.className = "btn";
            button.value = pharmacyEmail;
            button.onclick = function () {
                submitOffer(this.value, this.id);
            };
            button.appendChild(text);
            div.appendChild(button);
              
            document.getElementById("offers").appendChild(div);



        }
    });
});



var d = "";
var count = 0;

function submitOffer(email, idOffer) {
    d = JSON.parse(tenders.responseText);
    var tender = "";
   $.ajax({
        url: "/api/PharmacyOffers",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        method: 'GET',
        data: JSON.stringify({})
   }).then(function (data) {

       for (i = 0; i < data.length; i++) {
           if (data[i].id == idOffer) {
               tender = data[i].entityDTO.idTender;
               break;
           }
       }

       for (j = 0; j < data.length; j++) {
           if (data[j].entityDTO.idTender == tender) {               
               count++;
               if (data[j].id != idOffer) {
                   $.ajax(
                       {
                           type: "DELETE",
                           url: "/api/PharmacyOffers?id=" + data[j].id+"&approve=false",
                           data: {
                               id: data[j].id,
                               approve:false
                           },

                           success: function (result) {
                               alert("Succeseffuly done!");
                               location.reload();
                           },
                           error: function (data, ajaxOptions, thrownError) {
                               console.log('Error:', data);
                               alert("Cant be sent!");
                               location.reload();
                           }

                       });                   

               }
               var idTendera = data[j].entityDTO.idTender
               if (data[j].id == idOffer) {

                   $.ajax(
                       {
                           type: "DELETE",
                           url: "/api/PharmacyOffers?id=" + data[j].id + "&approve=true",
                           data: {
                               id: data[j].id,
                               approve:true
                           },

                           success: function (result) {
                               alert("Succeseffuly done!");
                               
                               $.ajax(
                                   {
                                       type: "DELETE",
                                       url: "/api/Tender?id=" + idTendera,
                                       data: {
                                           id: idTendera
                                       },

                                       success: function (result) {
                                           location.reload();
                                       },
                                       error: function (data, ajaxOptions, thrownError) {
                                           console.log('Error:', data);
                                           alert("Cant be sent!");
                                           location.reload();
                                       }

                                   });
                               

                               alert("Tender closed!");
                               location.reload();
                               
                           },
                           error: function (data, ajaxOptions, thrownError) {
                               console.log('Error:', data);
                               alert("Cant be sent!");
                               location.reload();
                           }

                       });


               }               
           }
       }

       
    });

   

}



