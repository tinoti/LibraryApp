using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LibraryApp.Dtos;
using LibraryApp.Models;

namespace LibraryApp.App_Start
{
    public class MappingProfile
    {

        public IMapper MapReservation()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Reservation, ReservationDto>();
                    cfg.CreateMap<ReservationDto, Reservation>();
                });

            return config.CreateMapper();
        }


        public IMapper MapBook()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDto>();
                cfg.CreateMap<BookDto, Book>()
                    .ForMember(dest => dest.Id,
                        act => act.Ignore());
            });

            return config.CreateMapper();
        }
    }
}