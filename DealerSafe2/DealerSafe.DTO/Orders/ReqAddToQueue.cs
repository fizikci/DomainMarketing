using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqAddToQueue
    {
        public BasketDetail Basket { get; set; }
        public HostingUpgradeDetail HostingUpgrade { get; set; }
        public int QueueReport { get; set; }
    }
}
