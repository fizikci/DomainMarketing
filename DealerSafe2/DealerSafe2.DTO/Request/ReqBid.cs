using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqBid : BaseRequest
    {
        public string DMItemId { get; set; }

        public int MaxBidValue { get; set; }

        public int BidValue { get; set; }

        public string BidComments { get; set; }

    }
}
