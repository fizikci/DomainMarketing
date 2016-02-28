using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqClassicVPosPayment
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

        [Description("Installment of the payment")]
        public int InstallmentNumber { get; set; }

        [Description("Order number of the payment")]
        public string OrderID { get; set; }

        [Description("Type of the payment")]
        public int PaymentType { get; set; }

        [Description("Credit ID of the payment")]
        public string CreditID { get; set; }

        [Description("Specified of the Credit ID")]
        public bool CreditIDSpecified { get; set; }

        [Description("Total Price(Turkish Lira) of the payment")]
        public double TotalPriceTL { get; set; }

        [Description("Bank number of the payment")]
        public int BankID { get; set; }

        [Description("IP address of the member")]
        public string IPAddress { get; set; }
    }
}
