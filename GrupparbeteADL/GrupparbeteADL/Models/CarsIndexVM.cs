using GrupparbeteADL.Attributes;
using GrupparbeteADL.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupparbeteADL.Models
{
    public class CarsIndexVM
    {
        public string Brand { get; set; }

        public int TopSpeed { get; set; }

        public int Id { get; set; }

        public string Model { get; set; }

        public int Doors { get; set; }

        public string OwnerName { get; set; }

        [DataType(DataType.Password)]
        [MustMatch("AlexMamma123")]
        [Required(ErrorMessage = "*Required")]
        public string Password { get; set; }

        public bool ShowAsFast { get; set; }


    }
}
