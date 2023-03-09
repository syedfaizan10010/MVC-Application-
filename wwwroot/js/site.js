// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $(document).ready(function () {
        $('.edit-button').on('click', function () {
            var rowId = ($(this).data('id'));
            console.log(rowId)
            window.location.href = '/Employee/UpdateEmployee?id=' + rowId;

        });
    })


    $(document).ready(function () {
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
        });
