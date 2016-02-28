using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class GetBankRateInfo
    {
        public List<BankRateDetail> BankRatelist { get; set; }
        public class BankRateDetail
        {
            public int Id { get; set; }
            public int lngBankID { get; set; }
            public int intRateNumber { get; set; }
            public float dbRateCredit { get; set; }
            public float dbBonusCredit { get; set; }
        }
    }
}
