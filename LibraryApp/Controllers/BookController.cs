using LibraryApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        [Route("Book/Details/{id}")]
        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.BookGenre).SingleOrDefault(b => b.Id == id);

            if (book == null)
                return HttpNotFound();

            return View(book);
            
        }

    }
}