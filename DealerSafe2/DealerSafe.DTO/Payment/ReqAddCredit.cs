using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqAddCredit
    {
        public int PaymentTypeID { get; set; }
        public int BankID { get; set; }
        public double CreditAmount { get; set; }
        public double PaymentAmount { get; set; }
        public string PriceType { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentTime { get; set; }
        public int Is3DSecure { get; set; }
        public int Rate { get; set; }
    }
}
