$(document).ready(function () {
   

    $.ajax({
        url: "/api/Tender",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({})
    }).then(function (data) {
        for (i = 0; i < data.length; i++) {
            if (data[i].entityDTO.opened == true) {
                document.getElementById("tenderTable").insertRow(-1)
                    .innerHTML = '<tr><td id="">' + data[i].entityDTO.name + '</td><td id="" >'
                    + data[i].entityDTO.descritpion + '</td><td>'
                    + data[i].entityDTO.startDate + '</td><td>'
                    + data[i].entityDTO.endDate + '</td><td><a href="'
                    + data[i].entityDTO.formLink + '">Check in</a></td></tr >'



            }
        }
    });
 });