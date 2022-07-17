using System;

namespace TelegramMessageConsumer.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string TlgId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public bool IsResponse { get; set; }
    }
}
