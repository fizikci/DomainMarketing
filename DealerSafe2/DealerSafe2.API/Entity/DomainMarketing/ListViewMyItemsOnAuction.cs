using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewMyItemsOnAuction : BaseEntity
    {
        public string DMAuctionId { get; set; }
        public int BiggestBid { get; set; }
        public DMItemTypes Type { get; set; }
        public string DomainName { get; set; }
        public DateTime StartDate { get; set; }
        public int BuyItNowPrice { get; set; }
        public DMAuctionStates Status { get; set; }
        public string SellerMemberId { get; set; }
    }
}