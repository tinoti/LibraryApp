using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }

        public IEnumerable<BookGenre> Genres { get; set; }

    }
}