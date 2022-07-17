using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramMessageConsumer.Middleware
{
    public struct PoolMessageRequest
    {
        public string TlgMessageId { get; set; }
    }
}
