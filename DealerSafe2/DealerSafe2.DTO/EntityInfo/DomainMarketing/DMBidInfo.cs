using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class DMBidInfo : BaseEntityInfo
    {

        public string DMAuctionId { get; set; }

        public string BidderMemberId { get; set; }

        public int BidValue { get; set; }

        public string BidComments { get; set; }
    }
}
