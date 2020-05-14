using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp.Dtos
{
    public class UpdateReservationDto
    {
        public int ReservationId { get; set; }

        public int StatusId { get; set; }

    }
}