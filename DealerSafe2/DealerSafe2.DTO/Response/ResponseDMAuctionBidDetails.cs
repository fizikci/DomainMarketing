using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Response
{
    public class ResponseDMAuctionBidDetails
    {
        public string Id {get;set;}
        public int BiggestBid {get;set;}
        public int MinimumBidPrice {get;set;}
        public int MinimumBidInterval {get;set;}
        public string DomainName {get;set;}
        public int BuyItNowPrice { get; set; }
        public DMAuctionStates Status { get; set; }
    }
}
