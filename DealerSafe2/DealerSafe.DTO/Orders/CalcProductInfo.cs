using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class CalcProductInfo
    {
        public bool Process { get; set; }
        public double OrderAmountDolar { get; set; }
        public double OrderAmountDolarYtl { get; set; }
        public double UsdSelling { get; set; }
    }
}
