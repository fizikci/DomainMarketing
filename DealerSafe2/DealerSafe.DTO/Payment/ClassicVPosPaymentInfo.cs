using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ClassicVPosPaymentInfo
    {
        public bool Process { get; set; }
        public bool IsPaid { get; set; }
        public bool TransRes { get; set; }
        public CreditCardStatusForErrors CardStatus { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorMessage { get; set; }
        public string Extra { get; set; }
    }
    public enum CreditCardStatusForErrors
    {
        NormalCard = 1,
        StolenCard = 2,
        SuspiciousCard = 3
    }
}
