using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqPaymentFormValidate
    {
        [Description("Total price of the payment")]
        public double TotalPrice { get; set; }

        [Description("Order number of the payment")]
        public string OrderID { get; set; }

        [Description("Bank number of the payment")]
        public int BankID { get; set; }

        [Description("Sender's name of the payment")]
        public string Name { get; set; }

        [Description("Date of the payment")]
        public string PaymentDate { get; set; }

        [Description("Description of the payment")]
        public string Description { get; set; }

        [Description("Currency of the payment")]
        public int Currency { get; set; }
        
        [Description("Credit ID of the payment")]
        public string CreditID { get; set; }

        [Description("Specified of the Credit ID")]
        public bool CreditIDSpecified { get; set; }

        [Description("Amount of the member's credit")]
        public double CreditAmount { get; set; }

        [Description("Amount(USD) of the payment")]
        public double OdenecekUSD { get; set; }

        [Description("Amount(TL) of the payment")]
        public double OdenecekTL { get; set; }

    }
}
