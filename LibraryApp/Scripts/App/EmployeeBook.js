$(document).ready(function () {




    //Language object for datatable
    var language = {
        "decimal": "",
        "emptyTable": "Nema podataka",
        "info": "Prikazuje se _START_ - _END_ od _TOTAL_ knjiga",
        "infoEmpty": "Nema podataka",
        "infoFiltered": "(filtrirano od _MAX_ knjiga)",
        "infoPostFix": "",
        "thousands": ",",
        "lengthMenu": "Prikaži _MENU_ knjiga",
        "loadingRecords": "Učitavanje...",
        "processing": "Procesuiranje...",
        "search": "Pretraga:",
        "zeroRecords": "Nema podataka",
        "paginate": {
            "first": "Prva",
            "last": "Zadnja",
            "next": "Slijedeća",
            "previous": "Prethodna"
        }};

    $('#booksTable').DataTable({
        ajax: {
            url: "/api/books",
            dataSrc: ""
        },
        language: language,      
        columns: [
            {
                data: "Name",
                render: function (data, type, book) {
                    return "<a href='/Book/Details/" + book.Id + "'>" + book.Name + "</a>";
                }
            },
            {
                data: "Author"
            },
            {
                data: "NumberAvailable"
    
            },
            {
                data: "Id",
                render: function(data) {
                    return "<a href='Book/Edit/" + data + "' class='btn btn-primary'>Uredi</a>";
                }
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn btn-primary deleteBook' data-book-id='" + data + "'>Izbriši</button>";
                }
            }
            ]
    });


    $('#booksTable').on("click", ".deleteBook", function () {
        var button = $(this);
        
   
        bootbox.confirm("Jesi li siguran da želiš izbrisati knjigu?", function (result) {


            if (result) {
                $.ajax({
                    url: "/api/books/" + button.attr("data-book-id"),
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                    }

                });

            }
            
        });
    });
 


});






