$(document).ready(function () {
    $('#statusForm').submit(function (event) {

        event.preventDefault();

        var MembershipCardNumber = $('#MembershipCardNumber').val();


        $.ajax({
            url: "/api/reservations/" + MembershipCardNumber,
            method: "GET",
            dataType: "json",
            success: function (data) {

                var text = "";

                if (data.length == 0)
                    text = "Nema niti jedne rezervacije.";
                else {
                    data.forEach(function (reservation) {
                        var textConcat = "<strong>Broj rezervacije: </strong>" + reservation.Id + "<br><strong>Knjiga: </strong> " + reservation.Book.Name + "<br> <strong>Status: </strong>" + reservation.ReservationStatus.Name + "<br><br>";
                        text += textConcat;

                    });

                }             
                bootbox.alert(text);

                //Clear member id 
                $('#MembershipCardNumber').val('');
            },
            error: function (error) {
                if (error.status == 404)
                    toastr.error("Članska iskaznica ne postoji!");
            }
        });

    });


});