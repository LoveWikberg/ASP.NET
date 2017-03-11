using Guldrullen.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guldrullen.Models
{
    public class MoviesIndexVM
    {
        public string Title { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }
        public string Comfirmation { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
