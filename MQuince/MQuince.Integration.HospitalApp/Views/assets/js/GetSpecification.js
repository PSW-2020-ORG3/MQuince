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