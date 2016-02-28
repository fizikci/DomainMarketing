using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqThreeDSecureParams
    {
        [Description("ID of the member")]
        public int MemberId { get; set; }

        [Description("Holder name of the credit card")]
        public string HolderName { get; set; }

        [Description("Email address of the member")]
        public string EmailAddress { get; set; }

        [Description("Card number of the credit card")]
        public string CardNumber { get; set; }

        [Description("CVV2 number of the credit card")]
        public string CVV2Number { get; set; }

        [Description("Expired year of the credit card")]
        public string ExpiredYear { get; set; }

        [Description("Expired year of the credit card")]
        public string ExpMonth { get; set; }

        [Description("Total price(Turkish lira) of the basket")]
        public double TotalPriceTL { get; set; }

        [Description("Card type of the credit card")]
        public CreditCardTypeDetail CardType { get; set; }

        [Description("Installment of the payment")]
        public int InstallmentNumber { get; set; }

        [Description("Order number of the payment")]
        public string OrderID { get; set; }

        [Description("Bank type of the payment")]
        public BankList Bank { get; set; }

        [Description("Sub bank type of the payment")]
        public BankList SubBank { get; set; }

        [Description("IP address of the member")]
        public string IPAddress { get; set; }

        public string SessionID { get; set; }
    }
    public enum BankList
    {
        Garanti = 4,
        Fortis = 5,
        Akbank = 9,
        IsBankasi = 10,
        Finansbank = 11,
        YapiKredi = 12,
        HSBC = 13,
        TurkiyeFinans = 14,
        GarantiCepBank = 15,
        PayPal = 16,
        BankAsya = 17,
        KoopBank = 18,
        YapıKredi_IT = 19,
        Garanti_IT = 20,
        Garanti_KKTC = 21,
        FinansBank_IT = 22,
        IsBankasi_IT = 23,
        BankAsya_IT = 25,
        None = 0,
        BankAsya_KKTC = 28,
        FinansBank_KKTC = 29,
        IsBankasi_KKTC = 30,
        YapıKredi_KKTC = 27
    }
    public enum CreditCardTypeDetail
    {
        NONE = 0,
        VISA = 1,
        MASTERCARD = 2,
        AMERICANEXPRESS = 3,
        MAESTRO = 4
    }
}
