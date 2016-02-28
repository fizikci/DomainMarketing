using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class GetOrderDetailForOrderListInfo
    {
        public bool Process { get; set; }
        public string HeaderText { get; set; }//Header
        public int PromotionCount { get; set; }//Session["PromotionCount"]
        public int PromotionCountHost { get; set; }//Session["PromotionCount"]
        public string MessageDetails { get; set; } // Return olacak kısım
        public string MessageInfo { get; set; } // Set message property
        public string ErrorMessage { get; set; }
    }
}
