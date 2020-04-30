$(document).ready(function () {

    var list = [];

    $('#booksTable').DataTable({
        ajax: {
            url: "/api/books",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name"
            },
            {
                data: "Name",
                render: function(data) {
                    return "<button class='btn btn-primary bookReservation' data-book-id='" + data +"'>Rezerviraj</button>"
                }
            }
            ]
    });

    $('#booksTable').on("click", ".bookReservation", function (e) {

        var bookName = $(this).attr('data-book-id');

        var reservation = "<div>" + bookName + " <button class='btn btn-primary removeReservation' data-book-id='" + bookName + "'>Ukloni</button> </div>";

        list.push(bookName);

        $(this).attr('disabled', true);


        $('#bookList').prepend(reservation);



    });

    $('#bookList').on("click",".removeReservation", function() {

        
        $(this).parent().remove();

        var bookName = $(this).attr('data-book-id');

        var indexOfRemovedElement = list.indexOf(bookName);

        $("button[data-book-id='" + bookName + "']").attr('disabled', false);

        list.splice(indexOfRemovedElement, 1);

    });


    $('#makeReservation').on("click", function () {

        var url = "/Reservation/Index?";

        list.forEach(function(book) {
            url += "BookName=" + encodeURIComponent(book) + "&";
        });

        url = url.slice(0, -1);
        window.location.href = url;

    });




});