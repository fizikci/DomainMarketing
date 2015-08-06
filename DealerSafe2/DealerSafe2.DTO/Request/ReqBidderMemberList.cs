using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqBidderMemberList
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string id { get; set; }
    }
}

