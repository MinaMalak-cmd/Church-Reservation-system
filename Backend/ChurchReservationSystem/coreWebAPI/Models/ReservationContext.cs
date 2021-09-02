using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace coreWebAPI.Models
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Mass> Masses { get; set; }
    }
}


