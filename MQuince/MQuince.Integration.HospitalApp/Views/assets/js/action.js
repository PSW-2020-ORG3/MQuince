$('.table tbody').on('click', '.Approve', function () {
    $(this).closest('tr').remove();
});
$('.table tbody').on('click', '.Disapprove', function () {
    $(this).closest('tr').remove();
});




