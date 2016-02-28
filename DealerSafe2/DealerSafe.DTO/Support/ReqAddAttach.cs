using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Support
{
    public class ReqAddAttach
    {
        public string TicketId { get; set; }
        public string TicketPostId { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
    }
}
