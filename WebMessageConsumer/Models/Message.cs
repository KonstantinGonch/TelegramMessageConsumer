using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMessageConsumer.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public bool IsResponse { get; set; }
    }
}
