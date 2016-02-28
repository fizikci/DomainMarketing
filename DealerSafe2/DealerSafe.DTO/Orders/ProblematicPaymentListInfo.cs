using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ProblematicPaymentListInfo
    {
        public bool Process { get; set; }
        public List<ProblematicPaymentDetail> ProblematicPaymentList { get; set; }

        public class ProblematicPaymentDetail
        {
            public int OrderID { get; set; }
            public string PostDate { get; set; }
            public double PaymentAmount { get; set; }
            public string AdminNotices { get; set; }
        }
    }
}
