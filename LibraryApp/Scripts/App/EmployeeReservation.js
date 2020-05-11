$(document).ready(function () {

    //Language object for datatable
    var language = {
        "decimal": "",
        "emptyTable": "Nema podataka",
        "info": "Prikazuje se _START_ - _END_ od _TOTAL_ rezervacije",
        "infoEmpty": "Nema podataka",
        "infoFiltered": "(filtrirano od _MAX_ rezervacija)",
        "infoPostFix": "",
        "thousands": ",",
        "lengthMenu": "Prikaži _MENU_ rezervacija",
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

    $('#booksTable').DataTable({
        ajax: {
            url: "/api/reservations",
            dataSrc: ""
        },
        language: language,
        columns: [
            {
                data: "Book.Name"
                
            },
            {
                data: "Member.Name"
            }
            
        ]
    });


});
