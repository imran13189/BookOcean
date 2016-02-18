function AlertMessage(message)
{
    $(".alertBody").html(message);
    $("#alertModel").modal('show');
}