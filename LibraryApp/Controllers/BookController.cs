using LibraryApp.Models;
using LibraryApp.Models.Identity;
using LibraryApp.ViewModels;
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

            if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
                return View("EmployeeIndex");

            return View("Index");
        }


        [Authorize(Roles = RoleName.Admin + "," + RoleName.Employee)]
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(o => o.Id == id);
            if (book == null)
                return HttpNotFound();



            var viewModel = new BookViewModel
            {
                Genres = _context.BookGenres.ToList(),
                Book = book
            };

            ViewBag.Name = "Uredi";

            return View("AddOrEdit", viewModel);
        }


        [Route("Book/Details/{id}")]
        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.BookGenre).SingleOrDefault(b => b.Id == id);

            if (book == null)
                return HttpNotFound();

            return View(book);
            
        }

        [Authorize(Roles = RoleName.Admin + "," + RoleName.Employee)]
        public ActionResult New()
        {
            var viewModel = new BookViewModel
            {
                Book = new Book(),
                Genres = _context.BookGenres.ToList()
            };


            ViewBag.Name = "Dodaj novu knjigu";
            return View("AddOrEdit", viewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin + "," + RoleName.Employee)]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookViewModel
                {
                    Book = new Book(),
                    Genres = _context.BookGenres.ToList()
                };

                return View("AddOrEdit", viewModel);
            }

            if (book.Id == 0)
                _context.Books.Add(book);
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);

                bookInDb.Name = book.Name;
                bookInDb.Author = book.Author;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.NumberAvailable = book.NumberAvailable;
                bookInDb.Description = book.Description;
                bookInDb.BookGenreId = book.BookGenreId;
                bookInDb.ReleaseYear = book.ReleaseYear; 
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Book");
        }

    }
}