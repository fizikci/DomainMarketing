using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqGetBankRate
    {
        [Description("Request of the bank rate list.Default value : 0")]
        public int BankID { get; set; }

        [Description("Rate Number of the bank rate list.Default value : 0")]
        public int IntRateNumber { get; set; }
    }
}
