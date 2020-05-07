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
        public IHttpActionResult GetBooks(string query = null)
        {

            var booksQuery = _context.Books.Include(m => m.BookGenre);

            if (!String.IsNullOrWhiteSpace(query))
                booksQuery = booksQuery.Where(c => c.Name.Contains(query));


            var books = booksQuery.ToList();
            return Ok(mapper.Map<List<BookDto>>(books));
        }


        //GET /api/books/id
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BookDto>(book));
        }
    }
}
