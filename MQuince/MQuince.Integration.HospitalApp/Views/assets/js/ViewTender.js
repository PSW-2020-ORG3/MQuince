$(document).ready(function () {
   

    $.ajax({
        url: "/api/Tender",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({})
    }).then(function (data) {
        for (i = 0; i < data.length; i++) {
            
            if (parse(data[i].entityDTO.endDate) > parse(Date.now()) && parse(data[i].entityDTO.startDate) < parse(Date.now())) {
                document.getElementById("tenderTable").insertRow(-1)
                    .innerHTML = '<tr><td id="">' + data[i].entityDTO.name + '</td><td id="" >'
                    + data[i].entityDTO.descritpion + '</td><td>'
                    + parse(data[i].entityDTO.startDate) + '</td><td>'
                    + parse(data[i].entityDTO.endDate) + '</td><td><a href="'
                    + data[i].entityDTO.formLink + '">Check in</a></td></tr >'
            }
            if (parse(data[i].entityDTO.endDate) > parse(Date.now()) && parse(data[i].entityDTO.startDate) < parse(Date.now())) {
                if (data[i].entityDTO.opened == false) {
                    $.ajax(
                        {
                            type: "PUT",
                            url: "/api/Tender?id="+data[i].key+"&opened="+true,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: {
                                id: data[i].key,
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
                            url: "/api/Tender?id=" + data[i].key + "&opened=" + false,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: {
                                id: data[i].key,
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

function parse(date) {
    const d = new Date(date)
    return new Date(d.getTime() - d.getTimezoneOffset() * 60 * 1000).toISOString().split('T')[0]
}