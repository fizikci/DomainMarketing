using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class OrderListWithCouponInfo
    {
        public bool Process { get; set; }
        public List<OrderListDetail> OrderLists { get; set; }

        public class OrderListDetail
        {
            public int ROW { get; set; }
            public int ORDER_ID { get; set; }
            public DateTime ORDER_DATE { get; set; }
            public int COUPON_ID { get; set; }
            public double ORDER_TOTAL { get; set; }
            public decimal COUPON_VAL { get; set; }
            public double COUPON_UNX_VAL { get; set; }
            public int MEMBER_ID { get; set; }
            public double COUPON_DEC_VAL { get; set; }
        }
    }
}
