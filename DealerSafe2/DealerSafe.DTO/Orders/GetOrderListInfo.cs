using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class GetOrderListInfo
    {
        public bool Process { get; set; }
        public int RecordCount { get; set; }
        public string OrderListTitle { get; set; }
        public List<OrderListDetail> OrderList { get; set; }

        public class OrderListDetail
        {
            public int Row { get; set; }
            public int ID { get; set; }
            public string OrderDate { get; set; }
            public double OrderAmountYTL { get; set; }
            public int Process { get; set; }
            public string PaymentTypeID { get; set; }
            public int BankID { get; set; }
            public string OrderTime { get; set; }
            public string PaymentProcess { get; set; }
            public string AdminNotices { get; set; }
            public string Notices { get; set; }
            public int PaymentID { get; set; }
            public int InvoiceID { get; set; }
            public int ExecutedCreditReportsId { get; set; }
            public int ExecutedCouponId { get; set; }
        }
    }
}
