$(document).ready(function () {
    $('#statusForm').submit(function (event) {

        event.preventDefault();

        var MemberId = $('#MemberId').val();


        $.ajax({
            url: "/api/reservations/" + MemberId,
            method: "GET",
            dataType: "json",
            success: function (data) {

                var text = "";

                data.forEach(function (reservation) {
                    var textConcat = "<strong>Broj rezervacije: </strong>" + reservation.Id + "<br><strong>Knjiga: </strong> " + reservation.Book.Name + "<br> <strong>Status: </strong>" + reservation.ReservationStatus.Name + "<br><br>";
                    text+= textConcat;

                });
                bootbox.alert(text);

                //Clear member id 
                $('#MemberId').val('');
            }
        });

    });


});