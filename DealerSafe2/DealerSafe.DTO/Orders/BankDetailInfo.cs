using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class BankDetailInfo
    {
        public bool Process { get; set; }
        public BankDetailType BankDetail { get; set; }
        public class BankDetailType
        {
            public string HataMesaj { get; set; }
            public bool Hata { get; set; }
            public int LngBankID { get; set; }
            public int IntStatus { get; set; }
            public string StrBankName { get; set; }
            public string StrLogoLocation { get; set; }
            public string StrCardName { get; set; }
            public string StrVirtualPosUrl { get; set; }
            public string StrUsername { get; set; }
            public string StrPassword { get; set; }
            public string StrClientId { get; set; }
            public string StrPosno { get; set; }
            public string StrSecurityCode { get; set; }
            public string StrXmlLocation { get; set; }
            public int IntDefaultBank { get; set; }
            public double DbRateCredit { get; set; }
            public double DbBonusCredit { get; set; }
            public int Chk3D { get; set; }
            public string IsyeriAnahtari1 { get; set; }
            public int PesinIcinBankID { get; set; }
            public int DefaultForMemberIsNotInTurkey { get; set; }
            public string Str3DSecureVirtualPosUrl { get; set; }
            public string Str3DSecureKey { get; set; }
            public string Str3DSecureOkUrl { get; set; }
            public string Str3DSecureFailUrl { get; set; }
        }
    }
}
