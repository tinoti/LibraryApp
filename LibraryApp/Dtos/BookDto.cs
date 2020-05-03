using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LibraryApp.Models;

namespace LibraryApp.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] public string Author { get; set; }


        [Required]
        public DateTime ReleaseYear { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        public BookGenre BookGenre { get; set; }

        [Required]
        public int BookGenreId { get; set; }

        public string Description { get; set; }
    }
}