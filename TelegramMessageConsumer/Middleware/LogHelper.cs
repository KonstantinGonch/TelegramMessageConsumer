using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramMessageConsumer.Models;

namespace TelegramMessageConsumer.Middleware
{
    public class LogHelper
    {
        public async static void AddLogMessage(string content)
        {
            using (var dbContext = new AppDbContext())
            {
                var logMessage = new LogMessage
                {
                    Content = content,
                    DateTime = DateTime.Now
                };
                dbContext.LogMessages.Add(logMessage);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
