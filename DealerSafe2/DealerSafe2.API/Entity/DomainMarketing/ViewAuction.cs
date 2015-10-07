using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ViewAuction : BaseEntity
    {

        public string Id { get; set; }
        public int BuyItNowPrice { get; set; }
        public int PageRank { get; set; }
        public int BiggestBid { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public string SellerMemberId { get; set; }
        public string DomainName { get; set; }
        public string Name { get; set; }
        public int MinimumBidInterval { get; set; }


    }
}