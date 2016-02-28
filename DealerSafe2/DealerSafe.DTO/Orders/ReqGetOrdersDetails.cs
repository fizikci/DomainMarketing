using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqGetOrdersDetails
    {
        public int OrderID { get; set; }
        public int OrderDetailId { get; set; }
    }
}
