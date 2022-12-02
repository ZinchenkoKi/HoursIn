using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Timers.Entities
{
    internal class Context : DbContext
    {
        public Context()
        {
         Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=Timers;username=postgres;password=1234567;");
        }

        public DbSet<fileTime> fileTimes { get; set; } = null!;
    }
}
