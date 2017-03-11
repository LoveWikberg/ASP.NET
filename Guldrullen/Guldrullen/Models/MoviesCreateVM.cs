using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Guldrullen.Models
{
    public class MoviesCreateVM
    {
        [Display(Name = "Movie title")]
        [Required(ErrorMessage = "*Required field")]
        public string Title { get; set; }

        [Display(Name = "Length of movie (in minutes)")]
        [Required(ErrorMessage = "*Required field")]
        public int Length { get; set; }

        [Display(Name = "Movie genre")]
        [Required(ErrorMessage = "*Required field")]
        public string Genre { get; set; }
    }
}
