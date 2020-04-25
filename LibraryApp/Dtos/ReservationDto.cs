using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp.Dtos
{
    public class ReservationDto
    {

        public IEnumerable BookIds { get; set; }

        public int MemberId { get; set; }


    }
}