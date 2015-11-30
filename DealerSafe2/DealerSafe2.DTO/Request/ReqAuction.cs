using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.Request
{
    public class ReqAuction : BaseRequest
    {
        public string Id { get; set; }
        [Description("used if there exists a date due for the auction")]
        public DateTime PlannedCloseDate { get; set; }

        [Description("comments about the auction")]
        public string Comments { get; set; }
        [Description("direct buy price without participating in the auction, namely reserve price")]
        public int BuyItNowPrice { get; set; }
        [Description("minimum bid price that this item needs to be sold by an auction")]
        public int MinimumBidPrice { get; set; }

        [Description("minimum bidding interval accepted")]
        public int MinimumBidInterval { get; set; }

    }

}
