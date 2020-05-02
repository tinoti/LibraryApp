$(document).ready(function () {

    var list = [];

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
                data: "Name"
            },
            {
                data: "Name",
                render: function(data) {
                    return "<button class='btn btn-primary bookReservation' data-book-id='" + data +"'>Dodaj na listu</button>";
                }
            }
            ]
    });


    //Handles the reservation event
    $('#booksTable').on("click", ".bookReservation", function (e) {


        var bookName = $(this).attr('data-book-id');


        //Creates and adds a new reservation to the DOM list 
        var reservation = "<div>" + bookName + " <button class='btn btn-primary removeReservation' data-book-id='" + bookName + "'>Ukloni</button> </div>";
        $('#bookList').prepend(reservation);

        //Add to the list
        list.push(bookName);

        //Disable the add reservation button and change it's description
        $(this).attr('disabled', true);
        $(this).html("Dodano!");

        //Add greenBackground class (includes opacity) to the whole div
        $(this).parent().parent().addClass("greenBackground");

        

        



    });



    //Removes the reservation from the reservation list
    $('#bookList').on("click",".removeReservation", function() {

        var bookName = $(this).attr('data-book-id');

        var indexOfRemovedElement = list.indexOf(bookName);

        //Remove reservation from the DOM and from the list
        $(this).parent().remove();
        list.splice(indexOfRemovedElement, 1);

        
        //Get the button element in the datatable that corresponds with the reservation so we can return it to normal
        var reservationButton = $("button[data-book-id='" + bookName + "']")

        //Make it clickable again
        reservationButton.attr('disabled', false);

        //Remove green background and opacity
        reservationButton.parent().parent().removeClass("greenBackground");

        //Revert to original description
        reservationButton.html("Dodaj na listu");

    });


    //Handles the redirecting to Reservation view
    $('#makeReservation').on("click", function () {

        //Base url
        var url = "/Reservation/Index?";

        //Add data to the url query
        list.forEach(function(book) {
            url += "BookName=" + encodeURIComponent(book) + "&";
        });

        //Removes the last "&" from the query
        url = url.slice(0, -1);

        //Redirect
        window.location.href = url;

    });



});