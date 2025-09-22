using Microsoft.EntityFrameworkCore;
using IntroEFCore.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroEFCore
{
    public class AppDbContext : DbContext
    { 
        public DbSet<Cliente> Cliente { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=EFCore;Trusted_Connection=True;ConnectRetryCount=0");
        }
    }
}
