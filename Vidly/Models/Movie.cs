
using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The movie name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage =  "The genre is required.")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "The release date is required.")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage = "The number in stock must be between 1 and 20.")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}