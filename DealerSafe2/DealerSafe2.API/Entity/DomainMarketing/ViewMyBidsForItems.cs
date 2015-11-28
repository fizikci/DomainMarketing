using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ViewMyBidsForItems : BaseEntity
    {
        public string DMAuctionId { get; set; }
        public string BidderMemberId { get; set; }
        public int BidValue { get; set; }
        public string DomainName { get; set; }
        public DMItemTypes Type { get; set; }
        public int BiggestBid { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public int BuyItNowPrice { get; set; }
    }
}
