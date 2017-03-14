using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Guldrullen.Models
{
    public class MovieCreateVM
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "*Required")]
        public string Title{ get; set; }

        [Display(Name = "Lenth")]
        [Required(ErrorMessage = "*Required")]
        public int Length{ get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "*Required")]
        public string Genre{ get; set; }
    }
}
