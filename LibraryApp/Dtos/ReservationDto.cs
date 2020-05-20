using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp.Dtos
{
    public class ReservationDto
    {

        public List<BookDto> Books{ get; set; }

        public string MembershipCardNumber { get; set; }


    }
}