using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public Book Book { get; set; }

        [Required]
        public int BookId { get; set; }

        public Member Member { get; set; }

        [Required]
        public int MemberId { get; set; }

        public ReservationStatus ReservationStatus { get; set; }

        [Required]
        public int ReservationStatusId { get; set; }

        [Required]
        public DateTime ReservationTime { get; set; }


    }
}