//Create:
//Add Employee :
//Gettig the details of dropdown from db before psoting the Emp details in Db
$('#AddNewEmp').on('click', function () {
    window.location.href = 'Employee/AddNewEmployee';
});

//Posting Data by calling Ajax(Adding New Emoployee)

$('#btnSave').on('click', function () {
    var data = {
        EmpName: $("#EmpName").val(), //Reading text box values using Jquery 
        EmpCity: $("#EmpCity").val(),
        EmpStatus: $("#EmpStatus").val()

    };
    $.ajax({
        type: 'POST',
        url: "/Employee/AddNewEmployeePost",
        data: data,
        success: function () {
            window.location.href = '/Employee/GetEmployee';
            console.log("Successss")
        },
        error: function (e) {
            alert("Faileddd")
        }
    });
});



//Read:
//Displaying all the Employee Details:
$('#EmployeeReport').on('click', function () {
    window.location.href = 'Employee/getemployee'
});



//Update:
//Calling Updating Employee Controller 
//        $('.edit-button').on('click', function () {
//            var rowId = ($(this).data('id'));
//            console.log(rowId)
//            window.location.href = '/Employee/UpdateEmployee?id=' + rowId;

//        });

//$('#update-button').on('click', function () {
//    var data = {
//        EmpName: $("#EmpName").val(), //Reading text box values using Jquery 
//        EmpCity: $("#EmpCity").val(),
//        EmpStatus: $("#EmpStatus").val()

//    };
//    $.ajax({
//        type: 'POST',
//        url: "/Employee/UpdateEmployeePost",
//        data: data,
//        success: function () {
//            alert('Successsssss')
//            window.location.href = '/Employee/GetEmployee';
//            console.log("Successss")
//        },
//        error: function (e) {
//            alert("Faileddd")
//        }
//    });
//});




//Delete:
//Deleting Employee by calling ajax and passing the corresponding id to delete details

        $('.delete-button').on('click', function () {
            var rowId = $(this).data('id');

            $.ajax({
                type: 'POST',
                url: '/Employee/DeleteEmployee',
                data: { id: rowId },
                success: function () {
                    $('#EmployeeTable').find('[data-id="' + rowId + '"]').closest('tr').remove();
                },
                error: function (e) {
                    alert("hi")
                }
            });
        });








//$('#update-button').on('click', function () {
//    var data = {
//        EmpName: $('#EmpName').val(),
//        EmpCity: $('#EmpCity').val(),
//        EmpStatus: $('#EmpStatus').val()
//    };

//    $.ajax({
//        type: 'POST',
//        url: '/Employee/UpdateEmployeePost',
//        data: data,
//        success: function () {
//            console.log('Successfully added')
//        },
//        error: function (e) {
//            alert('faileddd')
//        }

//    });
//});


