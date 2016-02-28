using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class GetBankListInfo
    {
        public List<BankDetail> BankList { get; set; }
        public class BankDetail
        {
            public int lngBankID { get; set; }
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
            public decimal DbRateCredit { get; set; }
            public decimal DbBonusCredit { get; set; }
            public int Chk3D { get; set; }
            public string IsyeriAnahtari { get; set; }
            public int DefaultForMemberIsNotInTurkey { get; set; }
            public string Str3DSecureVirtualPosUrl { get; set; }
            public string Str3DSecureKey { get; set; }
            public string Str3DSecureOkUrl { get; set; }
            public string Str3DSecureFailUrl { get; set; }
            public int IntCompanyID { get; set; }
            public int Is3dCompatible { get; set; }
            public bool Is3dMandatory { get; set; }
        }
    }
}
