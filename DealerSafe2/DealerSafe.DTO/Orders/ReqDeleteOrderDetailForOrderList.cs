using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqDeleteOrderDetailForOrderList
    {
        public int OrderID { get; set; }
        public int OrderDetailID { get; set; }
    }
}
