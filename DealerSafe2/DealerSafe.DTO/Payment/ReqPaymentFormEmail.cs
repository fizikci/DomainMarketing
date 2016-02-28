using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqPaymentFormEmail
    {
        [Description("Bank number of the payment")]
        public int BankID { get; set; }

        [Description("Number of the payment type")]
        public int PaymentTypeID { get; set; }

        [Description("Order number of the payment")]
        public string OrderID { get; set; }

        [Description("Total price of the payment")]
        public double TotalPrice { get; set; }

        [Description("Description of the payment")]
        public string Description { get; set; }

    }
}
