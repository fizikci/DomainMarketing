using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class GetCreditsInfo
    {
        public bool Process { get; set; }
        public List<CreditDetail> Credits { get; set; }
        
        public class CreditDetail
        {
            public int creditID { get; set; }
            public int MemberID { get; set; }
            public int PaymentTypeID { get; set; }
            public int BankID { get; set; }
            public int Rate { get; set; }
            public double CreditAmount { get; set; }
            public double PaymentAmount { get; set; }
            public string PriceType { get; set; }
            public string PaymentDate { get; set; }
            public string PaymentTime { get; set; }
            public int Process { get; set; }
            public string IPAdresi { get; set; }
            public string KrediKartiNo { get; set; }
            public int Status { get; set; }
            public int CreditProcess { get; set; }
            public int Is3DSecure { get; set; }
            public string StrNameOnCard { get; set; }
            public string StrExpireMonth { get; set; }
            public string StrExpireYear { get; set; }
            public string StrCvcNumber { get; set; }
            public int IntCardType { get; set; }
            public string CardHolderName { get; set; }
        }
    }
}
