using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The Name field is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Release Date field is required")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "The Number In Stock field is required")]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "The Genre field is required")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}