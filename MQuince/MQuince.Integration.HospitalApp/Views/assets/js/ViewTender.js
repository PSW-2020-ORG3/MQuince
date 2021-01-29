$(document).ready(function () {  

    $.ajax({
        url: "/api/Tender",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({})
    }).then(function (data) {
        for (i = 0; i < data.length; i++) {
            console.log(data[i].entityDTO.name)

            if (parse(data[i].entityDTO.endDate) >= parse(Date.now()) && parse(data[i].entityDTO.startDate) <= parse(Date.now())) {
                var key = data[i].id;
                console.log(key);

                    document.getElementById("tenderTable").insertRow(-1)
                        .innerHTML = '<tr><td>' + data[i].entityDTO.name + '</td><td>'
                        + data[i].entityDTO.descritpion + '</td><td>'
                        + parse(data[i].entityDTO.startDate) + '</td><td>'
                        + parse(data[i].entityDTO.endDate) + '</td><td>' +
                        '<button onclick="saveData(this); return false;" id="' + data[i].id + '"class="saveData">Check in</button></td></tr> '

                
            }
            if (parse(data[i].entityDTO.endDate) > parse(Date.now()) && parse(data[i].entityDTO.startDate) < parse(Date.now())) {
                if (data[i].entityDTO.opened == false) {
                    $.ajax(
                        {
                            type: "PUT",
                            url: "/api/Tender?id="+data[i].id+"&opened="+true,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: {
                                id: data[i].id,
                                opened:true

                            },
                            success: function (result) {

                                location.reload();
                            },
                            error: function (data, ajaxOptions, thrownError) {
                                console.log('Error:', data);
                                location.reload();
                            }
                        });
                    
                }
            }
            if (parse(data[i].entityDTO.endDate) < parse(Date.now()) || parse(data[i].entityDTO.startDate) > parse(Date.now())) {
                if (data[i].entityDTO.opened == true) {
                    $.ajax(
                        {
                            type: "PUT",
                            url: "/api/Tender?id=" + data[i].id + "&opened=" + false,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: {
                                id: data[i].id,
                                opened: false

                            },
                            success: function (result) {
                                location.reload();
                            },
                            error: function (data, ajaxOptions, thrownError) {
                                console.log('Error:', data);
                                location.reload();
                            }
                        });

                   
               


                }
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



}


function parse(date) {
    const d = new Date(date)
    return new Date(d.getTime() - d.getTimezoneOffset() * 60 * 1000).toISOString().split('T')[0]
}