using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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
        private int REJECTED;

        private const int MAX_RESERVATIONS = 4;
        
        public ReservationsController()
        {
            _context = new ApplicationDbContext();
            mapper = new MappingProfile().MapReservation();
            REJECTED = 3;
        }




        //GET /api/reservations
        [Authorize(Roles = RoleName.Admin + "," + RoleName.Employee)]
        public IHttpActionResult GetReservations()
        {

            var reservations = _context.Reservations
                .Include(o => o.Book)
                .Include(o => o.Member)
                .Include(o => o.ReservationStatus)
                .ToList();

            return Ok(reservations);
        }

        //GET /api/reservations/id
        public IHttpActionResult GetReservation(string id)
        {
            Member member = _context.Members.SingleOrDefault(o => o.MembershipCardNumber == id);
            if (member == null)
                return NotFound();

            var reservations = _context.Reservations
                .Include(o => o.Book)
                .Include(o => o.Member)
                .Include(o => o.ReservationStatus)
                .ToList()
                .FindAll(o => o.MemberId == member.Id);

            return Ok(reservations);
        }


        //POST /api/reservations
        [HttpPost]
        public IHttpActionResult CreateReservation(ReservationDto reservationDto)
        {

            Member member = _context.Members.SingleOrDefault(o => o.MembershipCardNumber == reservationDto.MembershipCardNumber);
            if (member == null)
                return NotFound();

            //Find all reservations by the same member
            var reservations = _context.Reservations.ToList().FindAll(o => o.MemberId == member.Id);

            var numberOfReservations = reservations.Count;

            List<BookDto> successReservation = new List<BookDto>();
            List<BookDto> failReservation = new List<BookDto>();

            List<List<BookDto>> reservationsList = new List<List<BookDto>>();



            //Add reservations, if max reservations is reached or book is already in reservations, add to failReservation list, 
            //else add to successResevation list and to database
            foreach (BookDto book in reservationDto.Books)
            {
                if (numberOfReservations >= MAX_RESERVATIONS || reservations.Find(o => o.BookId == book.Id) != null)
                {
                    failReservation.Add(book);
                }
                else
                {
                    //Get book in db by id and check if it's available
                    var bookInDb = _context.Books.SingleOrDefault(b => b.Id == book.Id);
                    if (bookInDb == null)
                        return NotFound();

                    if (bookInDb.NumberAvailable <= 0)
                        return BadRequest();

                    //Update number in stock
                    bookInDb.NumberAvailable--;

                    //Add reservation
                    var reservation = new Reservation
                    {
                        BookId = book.Id,
                        MemberId = member.Id,
                        ReservationStatusId = 1,
                        ReservationTime = DateTime.Now
                    };

                    _context.Reservations.Add(reservation);

                    numberOfReservations++;

                    successReservation.Add(book);
                }                  
                
            }

            _context.SaveChanges();

            reservationsList.Add(successReservation);
            reservationsList.Add(failReservation);

            //Send list of failed and succedded reservations back for toastr display
            return Ok(reservationsList);
        }



        //PUT /api/reservations/1
        [HttpPut]
        [Authorize(Roles = RoleName.Admin + "," + RoleName.Employee)]
        public IHttpActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
        {

            var reservationInDb = _context.Reservations.Include(o => o.Book).SingleOrDefault( o => o.Id == updateReservationDto.ReservationId);
            if (reservationInDb == null)
                return NotFound();

            reservationInDb.ReservationStatusId = updateReservationDto.StatusId;

            //if the reservation is rejected, make book available again
            if (updateReservationDto.StatusId == REJECTED)
                reservationInDb.Book.NumberAvailable++;

            _context.SaveChanges();

            return Ok();
        }



    }
}
