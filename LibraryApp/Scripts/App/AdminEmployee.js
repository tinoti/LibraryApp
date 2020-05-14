$(document).ready(function () {

    //Language object for datatable
    var language = {
        "decimal": "",
        "emptyTable": "Nema podataka",
        "info": "Prikazuje se _START_ - _END_ od _TOTAL_ zaposlenika",
        "infoEmpty": "Nema podataka",
        "infoFiltered": "(filtrirano od _MAX_ zaposlenika)",
        "infoPostFix": "",
        "thousands": ",",
        "lengthMenu": "Prikaži _MENU_ zaposlenika",
        "loadingRecords": "Učitavanje...",
        "processing": "Procesuiranje...",
        "search": "Pretraga:",
        "zeroRecords": "Nema podataka",
        "paginate": {
            "first": "Prva",
            "last": "Zadnja",
            "next": "Slijedeća",
            "previous": "Prethodna"
        }
    };

    $('#employeeTable').DataTable({
        ajax: {
            url: "/api/employees",
            dataSrc: ""
        },
        language: language,
        columns: [
            {
                data: "Firstname"                
            },
            {
                data: "Lastname"
            },
            {
                data: "Email"
            },
            {
                data: "Id",
                render: function (data) {

                    return "<button class='btn btn-primary deleteEmployee' data-employee-id='" + data + "'>Izbriši</button>";
                }
            }
        ]
    });


    $('#employeeTable').on("click", ".deleteEmployee", function () {

        var button = $(this);

        bootbox.confirm("Jesi li siguran da želiš izbrisati zaposlenika?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/employees/" + button.attr("data-employee-id"),
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                    }

                });
            }

        });

    });
});