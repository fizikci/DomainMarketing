using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Response
{
    public class ResponseDMAuctionBidDetails
    {
        public int MinimumBidPrice { get; set; }
        public int BiggestBid { get; set; }
        public int MinimumBidInterval { get; set; }
        public int BuyItNowPrice { get; set; }
        public string Id { get; set; }
        public string DomainName { get; set; }

    }
}
