$('.edit-button').on('click', function () {
    var rowId = ($(this).data('id'));
    console.log(rowId)
    window.location.href = '/Employee/UpdateEmployee?id=' + rowId;

});


$('#btnUpdate').on('click', function () {
    var data = {
        EmpName: $("#EmpName").val(), //Reading text box values using Jquery 
        EmpCity: $("#EmpCity").val(),
        EmpStatus: $("#EmpStatus").val()
    };
    $.ajax({
        type: 'POST',
        url: "/Employee/UpdateEmployeePost/",
        data: data,
        success: function () {
            window.location.href = '/Employee/GetEmployee';
           alert("Successss")
        },
        error: function (e) {
            alert("Faileddd")
        }
    });
});


