using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqGetBankList
    {
        [Description("Request of the bank list.Default value : 0")]
        public int BankID { get; set; }
    }
}
