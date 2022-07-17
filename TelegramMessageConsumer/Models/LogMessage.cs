using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramMessageConsumer.Models
{
    public class LogMessage
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
    }
}
