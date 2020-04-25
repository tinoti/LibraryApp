using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using LibraryApp.App_Start;
using LibraryApp.Models.Identity;
using System.Data.Entity;
using LibraryApp.Dtos;

namespace LibraryApp.Controllers.API
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;
        private IMapper mapper;
        public BooksController()
        {
            _context = new ApplicationDbContext();
            mapper = new MappingProfile().MapBook();
        }

        //GET /api/books
        public IHttpActionResult GetBooks()
        {

            var books = _context.Books.Include(m => m.BookGenre).ToList();

            return Ok(mapper.Map<List<BookDto>>(books));
        }
    }
}
