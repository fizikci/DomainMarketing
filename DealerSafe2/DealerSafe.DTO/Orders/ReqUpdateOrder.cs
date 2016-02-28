using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqUpdateOrder
    {
        public int OrderID { get; set; }
        public double USDselling { get; set; }
        public double OrderAmountDolar { get; set; }
        public double OrderAmountYTL { get; set; }
        public string IPAdresi { get; set; }
    }
}
