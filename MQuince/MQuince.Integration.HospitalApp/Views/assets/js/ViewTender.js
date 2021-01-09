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
                var key = data[i].key;
                document.getElementById("tenderTable").insertRow(-1)
                    .innerHTML = '<tr><td>' + data[i].entityDTO.name + '</td><td>'
                    + data[i].entityDTO.descritpion + '</td><td>'
                    + data[i].entityDTO.startDate + '</td><td>'
                    + data[i].entityDTO.endDate + '</td><td>' +
                    '<button onclick="saveData(this); return false;" id="'+data[i].key+'"class="saveData">Check in</button></td></tr> '

               

            }
        }
    });

    
});

function saveData(data){
    $('.tenderTable tbody').on('click', '.saveData', function () {
        var row = $(this).closest("tr");
        var rowIndex = row.index();             
        localStorage.setItem("object_name", JSON.stringify(data.id));
        document.location.href = "http://localhost:49544/home/form";
    });



};

