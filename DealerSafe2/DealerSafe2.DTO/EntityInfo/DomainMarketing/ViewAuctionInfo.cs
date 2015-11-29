using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ViewAuctionInfo : BaseEntityInfo
    {
        public string DMItemId { get; set; }
        public int BuyItNowPrice { get; set; }
        public int PageRank { get; set; }
        public int BiggestBid { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public string SellerMemberId { get; set; }
        public string DomainName { get; set; }
        public string CategoryName { get; set; }
        public DMAuctionStates Status { get; set; }
        public int MinimumBidInterval { get; set; }
        public string Comments { get; set; }
    }
}
