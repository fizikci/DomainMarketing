using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class PurchaseOrderInfo
    {
        public int MemberId { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderDetailInfo> Details { get; set; }

    }

    public enum OrderStatus
    {
        Basket,
        Purchased,
        Canceled
    }
}
