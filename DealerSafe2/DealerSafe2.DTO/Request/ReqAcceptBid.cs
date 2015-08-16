using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqAcceptBid
    {
        public string SellerMemberId { get; set; }
        public string BidderMemberId {get;set;}
        public int BidValue { get; set;}
        public string DMItemId{ get; set;}
        public string DMAuctionId { get; set; }
    }
}
