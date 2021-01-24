$(document).ready(function () {

    $('.table tbody').on('click', '.send', function (data) {


        var table = document.getElementById('table'),
            rows = table.getElementsByTagName('tr'),
            i, j, cells, customerId;


        var name = document.getElementById("table").rows[1].getElementsByTagName('input')[0].value;
        var quantity = document.getElementById("table").rows[3].getElementsByTagName('input')[0].value;
        if (name == "" || quantity == "") {

            alert("You need to fill all fields!");
        } else if (quantity < 1) {
            alert("Quantity can't be negative!");
        } else if (name != "" || quantity != "") {
            alert("Medication sucesfully sent to the pharmacy!");
        }else {



            $.ajax({
                url: "/api/UrgentProcurement",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({})
            }).then(function (data) {
                for (i = 0; i < data.length; i++) {
                    if (name == data[i].entityDTO.name) {

                        $.ajax(
                            {
                                type: "PUT",
                                url: "/api/UrgentProcurement/" + data[i].id + "|" + quantity,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: {
                                    id: data[i].id,
                                    quntity: quantity
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

            });
        }

    });
});
function cache_clear() {
    window.location.reload(true);
}

