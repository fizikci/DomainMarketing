using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqGetCalculateOrderAmountWithCompany
    {
        public int OrderID { get; set; }
        public int PaymentType { get; set; }
        public int LngBankID { get; set; }
        public int IntRateNumber { get; set; }
        public double USDselling { get; set; }
        public int CompanyID { get; set; }
    }
}
