using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupparbeteADL.Models
{
    public class DisplayCreateVM
    {
        public CarsIndexVM[] ListViewModels { get; set; }
        public CarsCreateVM FormViewModels { get; set; }
    }
}
