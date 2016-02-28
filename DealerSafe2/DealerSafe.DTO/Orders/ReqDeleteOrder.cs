using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqDeleteOrder
    {
        public int OrderID { get; set; }
    }

    public class ReqDeleteOrders
    {
        public List<GetOrdersInfo.OrdersDetail> Orders { get; set; }
        
    }
}
