using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqBid
    {
        public string DMAuctionId { get; set; }

        public int MaxBidValue { get; set; }

        public int BidValue { get; set; }

        public string BidComments { get; set; }

    }
}
