using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqGetOrders
    {
        public int OrderId { get; set; }
        public bool OrderIDSpecified { get; set; }
    }
}
