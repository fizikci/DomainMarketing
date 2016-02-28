using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class CompleteOrderActionsInfo
    {
        public bool Process { get; set; }
        public DealerSafe.DTO.Orders.BasketDetail Basket { get; set; }
    }
}
