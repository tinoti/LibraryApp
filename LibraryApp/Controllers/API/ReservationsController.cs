﻿using System;
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

        private const int MAX_RESERVATIONS = 4;

        public ReservationsController()
        {
            _context = new ApplicationDbContext();
            mapper = new MappingProfile().MapReservation();
        }



        

        //POST /api/reservations
        [HttpPost]
        public IHttpActionResult CreateReservation(ReservationDto reservationDto)
        {

            //Number of reservations by same member id in database
            var numberOfReservations = _context.Reservations.ToList().FindAll(o => o.MemberId == reservationDto.MemberId).Count;

            List<BookDto> successReservation = new List<BookDto>();
            List<BookDto> failReservation = new List<BookDto>();

            List<List<BookDto>> reservationsList = new List<List<BookDto>>();


            //Add reservations, if max reservations is reached add to failReservation list, else add to successResevation list and to database
            foreach (BookDto book in reservationDto.Books)
            {
                if (numberOfReservations >= MAX_RESERVATIONS)
                {
                    failReservation.Add(book);
                }
                else
                {
                    //Get book in db by id and check if it's available, also checks if id is correct (Single throws exception if not found)
                    var bookInDb = _context.Books.Single(b => b.Id == book.Id);

                    if (bookInDb.NumberAvailable <= 0)
                        return BadRequest();

                    //Update number in stock
                    bookInDb.NumberAvailable--;

                    //Add reservation
                    var reservation = new Reservation
                    {
                        BookId = book.Id,
                        MemberId = reservationDto.MemberId
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
    }
}
