using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Razor;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [Display (Name = "Ime")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Godinja izdavanja")]       
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? ReleaseYear { get; set; }

        [Required]
        [Display(Name = "Sveukupno primjeraka")]
        public int NumberInStock { get; set; }

        [Display(Name = "Trenutno raspoloživo")]
        public int NumberAvailable { get; set; }

        public BookGenre BookGenre { get; set; }

        [Required]
        [Display(Name = "Žanr")]
        public int BookGenreId { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }



    }
}