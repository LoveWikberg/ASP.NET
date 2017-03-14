using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guldrullen.Models
{
    public class MovieDisplayVM
    {
        public MovieShowVM[] ListViewModels { get; set; }
        public MovieCreateVM FormViewModels { get; set; }

        public string Search { get; set; }

        public bool DisplayAction { get; set; }
        public bool DisplayComedy { get; set; }
        public bool DisplayRomance { get; set; }
    }
}
