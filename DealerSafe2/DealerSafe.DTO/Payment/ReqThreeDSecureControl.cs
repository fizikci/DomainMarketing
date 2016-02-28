using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqThreeDSecureControl
    {
        [Description("Holder name of the credit card")]
        public string HolderName { get; set; }

        [Description("Card number of the credit card")]
        public string CardNumber { get; set; }

        [Description("CVV2 number of the credit card")]
        public string CVV2Number { get; set; }

        [Description("Expired year of the credit card")]
        public string ExpiredYear { get; set; }

        [Description("Expired year of the credit card")]
        public string ExpMonth { get; set; }

        [Description("Card type of the credit card")]
        public CreditCardTypeDetail CardType { get; set; }

        [Description("Order number of the payment")]
        public string OrderID { get; set; }
        
        [Description("Credit ID of the payment")]
        public string CreditID { get; set; }

        [Description("Specified of the Credit ID")]
        public bool CreditIDSpecified { get; set; }

        [Description("Number of the bank")]
        public int BankID { get; set; }
    }
}
