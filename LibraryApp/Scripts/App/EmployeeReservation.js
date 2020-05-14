$(document).ready(function () {

    //these correspond to the status in database
    var pending = 1;
    var accept = 2;
    var reject = 3;

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

    var table = $('#reservationTable').DataTable({
        ajax: {
            url: "/api/reservations",
            dataSrc: function (data) {
                return data;
            }
        },       
        language: language,
        createdRow: function (row, data, dataIndex) {
            if (data.ReservationStatus.Id === pending) {
                $(row).addClass("pending");
                $(row).find(".default").attr("disabled", true);
            }
            else if (data.ReservationStatus.Id === accept) {
                $(row).addClass("accepted");
                $(row).find(".accept").attr("disabled", true);
            }

            else if (data.ReservationStatus.Id === reject) {
                $(row).addClass("rejected");
                $(row).find(".reject").attr("disabled", true);
            }                
        },
        columns: [
            {
                data: "Id"
            },
            {
                data: "Book.Name"
                
            },
            {
                data: "Member.Name"
            },
            {
                data: "ReservationStatus.Name"              
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn btn-primary accept' data-reservation-id='" + data + "'>Potvrdi</button>";
                }
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn btn-primary reject' data-reservation-id='" + data + "'>Odbij</button>";
                }
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn btn-primary default' data-reservation-id='" + data + "'>Stavi na čekanje</button>";
                }
            }
            
        ]
    });


    $('#reservationTable').on("click", ".accept", function () {

        var reservationId = $(this).attr('data-reservation-id');


        var data = { 'ReservationId': reservationId, 'StatusId': accept };
        bootbox.confirm("Pritisni Ok za potvrdu rezervacije", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/reservations",
                    method: "PUT",
                    data: data,
                    success: function () {
                        table.ajax.reload();
                    }

                });

            }

        });

    });

    $('#reservationTable').on("click", ".reject", function () {

        var reservationId = $(this).attr('data-reservation-id');

        var data = { 'ReservationId': reservationId, 'StatusId': reject };
        bootbox.confirm("Pritisni Ok za brisanje rezervacije", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/reservations",
                    method: "PUT",
                    data: data,
                    success: function () {
                        table.ajax.reload();
                    }

                });

            }

        });

    });

    $('#reservationTable').on("click", ".default", function () {

        var reservationId = $(this).attr('data-reservation-id');

        var data = { 'ReservationId': reservationId, 'StatusId': pending };
        bootbox.confirm("Pritisni Ok za reset rezervacije", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/reservations",
                    method: "PUT",
                    data: data,
                    success: function () {
                        table.ajax.reload();
                    }

                });

            }

        });

    });

    $('#accepted').on("click", function () {
        table.columns([3]).search("Potvrđeno").draw();
    });

    

    $('#rejected').on("click", function () {
        table.columns([3]).search("Odbijeno").draw();
    });


    $('#pending').on("click", function () {
        table.columns([3]).search("Čeka obradu").draw();
    });

    $('#allReservations').on("click", function () {
        table.columns().search("").draw();

    });

});
