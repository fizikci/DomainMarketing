using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqGetOrderDetail
    {
        public int OrderID { get; set; }
        public string IPAddress { get; set; }
    }
}
