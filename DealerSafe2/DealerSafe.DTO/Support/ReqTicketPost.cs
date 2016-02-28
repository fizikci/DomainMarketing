using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Support
{
    public class ReqTicketPost
    {
        public string TicketId { get; set; }
        public string Subject { get; set; }
        public string Contents { get; set; }
        public string UserId { get; set; }
    }
}
