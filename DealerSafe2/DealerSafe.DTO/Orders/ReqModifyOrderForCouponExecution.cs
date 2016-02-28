using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqModifyOrderForCouponExecution
    {
        public int OrderID { get; set; }
        public int TransactionId { get; set; }
    }
}
