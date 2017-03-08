using GrupparbeteADL.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GrupparbeteADL.Controllers
{
    public class CarsEditVM
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

        [DataType(DataType.Password)]
        [MustMatch("AlexMamma123")]
        [Required(ErrorMessage = "*Required")]
        public string Password { get; set; }

    }
}