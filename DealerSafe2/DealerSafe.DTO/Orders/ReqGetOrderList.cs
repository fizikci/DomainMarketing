using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqGetOrderList
    {
        public string ListType { get; set; }//
        public int PageIndex { get; set; }//
        public string SearchType { get; set; }//
        public string Search { get; set; }//
        public int OrderID { get; set; }
        public string PaymentTypeID { get; set; }
        public string ProductName { get; set; }
        public int PageLength { get; set; }//
    }
}
