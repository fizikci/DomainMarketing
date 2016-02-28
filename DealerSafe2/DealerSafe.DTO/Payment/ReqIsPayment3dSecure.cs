using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class ReqIsPayment3dSecure
    {
        public bool IsCreditPayment { get; set; }
        public int OrderId { get; set; }
        public int bankId { get; set; }


        [Description("Credit ID of the payment")]
        public double CreditAmount { get; set; }

        [Description("Specified of the Credit ID")]
        public bool CreditAmountSpecified { get; set; }
    }
}
