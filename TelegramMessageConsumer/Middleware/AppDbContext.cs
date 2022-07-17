using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramMessageConsumer.Models;

namespace TelegramMessageConsumer.Middleware
{
    public class AppDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessagePoolUnit> MessagePoolUnits { get; set; }
        public DbSet<LogMessage> LogMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=82.146.56.114;user=external;password=superFinashka;database=TlgConsumer;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
