

$(document).ready(function () {

    var bookList = [];
    var MAX_INPUT = 4;


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
        createdRow: function (row, data, dataIndex) {

            //Check if there is book on stock
            if (data.NumberAvailable === 0) {

                $(row).addClass("bookUnavailable");

                var button = $(row).find("button");
                button.attr("disabled", true);
                button.html("Trenutno nedostupno");
            }
        },
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
                data: "BookGenre.Name"
            },
            {
                data: "NumberAvailable"
    
            },
            {
                data: "Id",
                render: function(data) {
                    return "<button class='btn btn-primary bookReservation' data-book-id='" + data +"'>Dodaj na listu</button>";
                }
            }
            ]
    });


    //Handles the reservation event
    $('#booksTable').on("click", ".bookReservation", function (e) {

        var bookId = $(this).attr("data-book-id");
        bookId = parseInt(bookId);
        var currentButton = $(this);

        $.get("/api/books", function (data) {


            //Check if there is already maximum books added to the list
            if ($('#bookList').children('div').length === MAX_INPUT) {
                bootbox.alert("Dosegnut maksimalni broj rezervacija");
            } else {
                var book = data.find(o => o.Id === bookId);

                //Creates and adds a new reservation to the DOM list 
                var reservation = "<div class='row'> <div class='col-xs-4'> <p>" + book.Name + "</p> </div> <div class='col-xs-4'><button class='btn btn-primary removeReservation' data-book-id='" + book.Id + "'>Ukloni</button> </div> </div>";
                $('#bookList').append(reservation);


                //Add to the list
                bookList.push(book.Id); 

                //Update the number reserved
                $('#numberReserved').html("Broj rezervacija: " + bookList.length + "/4");

                //Disable the add reservation button and change it's description
                $(currentButton).attr('disabled', true);
                $(currentButton).html("Dodano!");

                //Add greenBackground class (includes opacity) to the whole div
                $(currentButton).parent().parent().addClass("greenBackground");

                //Show the reservation div
                $('#reservationList').show();

            }
        });
    });



    //Removes the reservation from the reservation list
    $('#bookList').on("click",".removeReservation", function() {

        var bookId = $(this).attr('data-book-id');

        var indexOfRemovedElement = bookList.indexOf(bookId);

        //Remove reservation from the DOM and from the list
        $(this).parent().parent().remove();
        bookList.splice(indexOfRemovedElement, 1);

        //Update the number reserved
        $('#numberReserved').html("Broj rezervacija: " + bookList.length + "/4");

        //If there is no reservations, hide the reservation div
        if(bookList.length === 0)
            $('#reservationList').hide();

        
        //Get the button element in the datatable that corresponds with the reservation so we can return it to normal
        var reservationButton = $("button[data-book-id='" + bookId + "']")

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
        bookList.forEach(function(bookId) {
            url += "BookId=" + encodeURIComponent(bookId) + "&";
        });

        //Removes the last "&" from the query
        url = url.slice(0, -1);

        //Redirect
        window.location.href = url;

    });



    //Makes the reservation list div follow the scrolling
    $(function () {

        var $sidebar = $("#reservationList"),
            $window = $(window),
            offset = $sidebar.offset(),
            topPadding = 50;

        $window.scroll(function () {
            if ($window.scrollTop() > offset.top) {
                $sidebar.stop().animate({
                    marginTop: $window.scrollTop() - offset.top + topPadding
                });
            } else {
                $sidebar.stop().animate({
                    marginTop: 0
                });
            }
        });

    });


   



});






