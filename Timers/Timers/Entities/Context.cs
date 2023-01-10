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
        public DbSet<TimeValueInFile> timeValueInFiles { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Timer2;Username=postgres;Password=1234567");       
        }
     }
}
