using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GrupparbeteADL.Models.Entities
{
    public partial class EastwindContext : DbContext
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        
    }
}