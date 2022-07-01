using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMessageConsumer.Models;

namespace WebMessageConsumer.Middleware
{
    public class AppDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=82.146.56.114;user=external;password=superFinashka;database=TlgConsumer;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
