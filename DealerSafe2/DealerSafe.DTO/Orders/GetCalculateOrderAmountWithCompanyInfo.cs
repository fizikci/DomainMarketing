using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class GetCalculateOrderAmountWithCompanyInfo
    {
        public bool Process { get; set; }
        public double OrderAmountDolar { get; set; }
        public double OrderAmountYTL { get; set; }
    }
}
