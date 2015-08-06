using System;
using System.Collections.Generic;
using System.Linq;
using DealerSafe2.DTO.EntityInfo.DomainMarketing;
using System.Collections.Generic;

namespace DealerSafe2.DTO.Response
{
    public class ResBidderMemberListWithRows
    {

        public List<DMBidderMemberInfo> Bids { get; set; }
        public int rowCount { get; set; }
    }
}
