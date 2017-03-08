using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupparbeteADL.Models
{
    [Bind(Prefix = nameof(DisplayCreateVM.FormViewModels))]
    public class CarsCreateVM
    {
        [Display(Name = "Make")]
        [Required(ErrorMessage = "*Required")]
        public string Brand { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "*Required")]
        public string Model { get; set; }

        [Display(Name = "Number of doors")]
        [Required(ErrorMessage = "*Required")]
        [Range(2, 6, ErrorMessage = "Min: 2, Max: 6")]
        public int Doors { get; set; }

        [Display(Name = "Top-speed")]
        [Required(ErrorMessage = "*Required")]
        [Range(0, 300, ErrorMessage = "Enter valid top-speed between 0-300 km/h.")]
        public int TopSpeed { get; set; }
    }
}
