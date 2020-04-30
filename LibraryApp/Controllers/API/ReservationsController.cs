using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using LibraryApp.App_Start;
using LibraryApp.Dtos;
using LibraryApp.Models;
using LibraryApp.Models.Identity;


namespace LibraryApp.Controllers.API
{
    public class ReservationsController : ApiController
    {
        private ApplicationDbContext _context;
        private IMapper mapper;

        public ReservationsController()
        {
            _context = new ApplicationDbContext();
            mapper = new MappingProfile().MapReservation();
        }



        

        //POST /api/reservations
        [HttpPost]
        public IHttpActionResult CreateReservation(ReservationDto reservationDto)
        {

            foreach (string bookName in reservationDto.BookNames)
            {
                Book book = _context.Books.Single(c => c.Name == bookName);

                
                
                var reservation = new Reservation
                {
                     BookId = book.Id,
                     MemberId = reservationDto.MemberId
                };

                _context.Reservations.Add(reservation);
            }

            
            _context.SaveChanges();

            return Ok();
        }
    }
}
