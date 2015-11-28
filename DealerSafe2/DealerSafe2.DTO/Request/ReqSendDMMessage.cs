using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqSendDMMessage
    {
        public string ToMemberId { get; set; }
        public string DMPredefinedMessageId { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

    }
}
