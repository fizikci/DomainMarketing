using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class GiftVoucherInfo
    {
        public bool Process { get; set; }
        public List<GiftVoucherDetail> GiftVouchersList { get; set; }

        public class GiftVoucherDetail
        {
            public int Id { get; set; }
            public string RecDate { get; set; }
            public bool RecStatus { get; set; }
            public int OrderId { get; set; }
            public string VoucherCode { get; set; }
            public string VoucherCurrency { get; set; }
            public double VoucherAmount { get; set; }
            public double ExecutedAmount { get; set; }
            public double NotExecutedAmount { get; set; }
            public int CreatedBy { get; set; }
            public int AssignedTo { get; set; }
            public int ExecutionStatus { get; set; }
            public string ExecutedDate { get; set; }
            public int ExecutedForOrder { get; set; }
            public string ProductRelation { get; set; }
        }
    }
}
