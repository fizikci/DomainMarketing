using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ViewMyBidsForItemsInfo : BaseEntityInfo
    {
        public string Id { get; set; }
        public string DMAuctionId { get; set; }
        public string BidderMemberId { get; set; }
        public int BidValue { get; set; }
        public DateTime InsertDate { get; set; }
        public bool IsDeleted { get; set; }
        public string DomainName { get; set; }
        public DMItemTypes Type { get; set; }
        public int BiggestBid { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public int BuyItNowPrice { get; set; }
    }
}
