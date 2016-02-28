using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class GetOrderDetailInfo
    {
        public bool Process { get; set; }
        public string DetailMessage { get; set; }
        public int PromotionCount { get; set; } // Session["PromotionCount"]
        public int PromotionCountHost { get; set; } // Session["PromotionCountHost"]
        public string OdenecekUSD { get; set; } // Session["OdenecekUSD"]
        public string OdenecekTL { get; set; } // Session["OdenecekTL"]
        public string LastBalancePrice { get; set; } //ToplamkalanOdenecekBakiye
        public string ErrorMessage { get; set; }
    }
}
