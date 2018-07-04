using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required(ErrorMessage = "The movie name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "The genre is required.")]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "The release date is required.")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage = "The number in stock must be between 1 and 20.")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        public MovieFormViewModel()
        {
            Id = 0;
            ReleaseDate = DateTime.MinValue;
            NumberInStock = 0;
        }
    }
}