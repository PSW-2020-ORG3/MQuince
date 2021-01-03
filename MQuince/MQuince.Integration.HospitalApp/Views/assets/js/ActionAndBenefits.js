$(document).ready(function () {
        setInterval(function () {
            cache_clear()
        }, 5000);   

    $.ajax({
        url: "/api/ActionAndBenefits",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({})
    }).then(function (data) {
        for (i = 0; i < data.length; i++) {
            if (data[i].isApproved == false) {
                document.getElementById("tabelAction").insertRow(1)
                    .innerHTML = '<tr><td id="pharmacyName">' + data[i].entityDTO.pharmacyName + '</td><td id="actionName" >'
                + data[i].entityDTO.actionName + '</td><td id="beginDate">'
                + data[i].entityDTO.beginDate + '</td><td id="endDate">'
                + data[i].entityDTO.endDate + '</td><td id="oldCost">'
                + data[i].entityDTO.oldCost + '</td><td id="newCost">'
                    + data[i].entityDTO.newCost + '</td >'
                + '<td><button class="approve">Approve</button></td>'
                    + '<td><button class="disapprove">Disapprove</button></td></tr>'
            }
        }
    });
    

   
    $('.table tbody').on('click', '.disapprove', function (data) {
       
        var row = $(this).closest("tr");
        var rowIndex = row.index();
        var pharmacyName = row.children('#pharmacyName').text();
        var actionName = row.children('#actionName').text();
        var beginDate = row.children('#beginDate').text();
        var endDate = row.children('#endDate').text();
       

        $.ajax({
            url: "/api/ActionAndBenefits",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({})
        }).then(function (data) {
            for (i = 0; i < data.length; i++) {
                if (data[i].isApproved == false) {
                    if (pharmacyName == data[i].entityDTO.pharmacyName &&
                        actionName == data[i].entityDTO.actionName &&
                        beginDate == data[i].entityDTO.beginDate &&
                        endDate == data[i].entityDTO.endDate) {
                        $.ajax(
                            {
                                type: "DELETE",
                                url: "/api/ActionAndBenefits",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: JSON.stringify({
                                    IDAction: data[i].key,
                                    IsApproved: data[i].isApproved,
                                    PharmacyName: data[i].entityDTO.pharmacyName,
                                    ActionName: data[i].entityDTO.actionName,
                                    BeginDate: getYYYYMMDD(data[i].entityDTO.beginDate),
                                    EndDate: getYYYYMMDD(data[i].entityDTO.endDate),
                                    OldCost: parseFloat(data[i].entityDTO.oldCost),
                                    NewCost: parseFloat(data[i].entityDTO.newCost),

                                }),
                                success: function (result) {

                                    alert("Successefully deleted action!");
                                    location.reload();
                                },
                                error: function (data, ajaxOptions, thrownError) {
                                    console.log('Error:', data);
                                    alert("Cant be deleted!");
                                    location.reload();
                                }

                            });
                    }
                }
            }
        });

        $(this).closest('tr').hide();

    });

   

    $('.table tbody').on('click', '.approve', function (data) {       
        var row = $(this).closest("tr");
        var rowIndex = row.index();
        var pharmacyName = row.children('#pharmacyName').text();
        var actionName = row.children('#actionName').text();
        var beginDate = row.children('#beginDate').text();
        var endDate = row.children('#endDate').text();
        
       
        console.log(rowIndex)
        $.ajax({
            url: "/api/ActionAndBenefits",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({})
        }).then(function (data) {
            for (i = 0; i < data.length; i++) {
                
                if (data[i].isApproved == false) {
                    if (pharmacyName == data[i].entityDTO.pharmacyName &&
                        actionName == data[i].entityDTO.actionName &&
                        beginDate == data[i].entityDTO.beginDate &&
                        endDate == data[i].entityDTO.endDate) {

                        console.log("USAO UOPSTE?");
                       $.ajax(
                            {
                                type: "PUT",
                                url: "/api/ActionAndBenefits",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: JSON.stringify({
                                    IDAction: data[i].key,
                                    PharmacyName: data[i].entityDTO.pharmacyName,
                                    ActionName: data[i].entityDTO.actionName,
                                    BeginDate: getYYYYMMDD(data[i].entityDTO.beginDate),
                                    EndDate: getYYYYMMDD(data[i].entityDTO.endDate),
                                    OldCost: parseFloat(data[i].entityDTO.oldCost),
                                    NewCost: parseFloat(data[i].entityDTO.newCost),
                                    IsApproved: "true"

                                }),
                                success: function (result) {

                                    alert("Successefully approved action!");
                                    location.reload();
                                },
                                error: function (data, ajaxOptions, thrownError) {
                                    console.log('Error:', data);
                                    alert("Action can't be approved!");
                                    location.reload();
                                }
                            });
                    }
                }
            }
          });

        $(this).closest('tr').hide()

    });



});


function getYYYYMMDD(d0) {
    const d = new Date(d0)
    return new Date(d.getTime() - d.getTimezoneOffset() * 60 * 1000).toISOString().split('T')[0]
}

function cache_clear() {
    window.location.reload(true);    
}




