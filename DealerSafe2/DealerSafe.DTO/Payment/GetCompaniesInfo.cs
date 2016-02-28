using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class GetCompaniesInfo
    {
        public bool Process { get; set; }
        public List<CompanyInfoDetail> CompanyInfo { get; set; }

        public class CompanyInfoDetail
        {
            public bool IsCompanyInfoOk;
            public int CompanyId;
            public string CompanyName;
            public bool IsActive;
            public int IsDefault;
            public int CommisionRate;
            public double ShippingCostUSD;
            public bool KrediKartiPesin;
            public bool KrediKartiTaksit;
            public bool MailOrderPesin;
            public bool MailOrderTaksit;
            public bool BankaHavalesi;
            public bool PostaCeki;
            public bool BonusPay;
            public bool PayPal;
            public bool Mobile;
            public bool KrediKartiPuanKullanimi;
            public int OperationTaxRate;
            public int ShippingTaxRate;
            public int DefaultBankId;
            public double defaultBankCommision; // db den hatalı veri geldiği durumlarda kullanılmak üzere düşünüldü.
            public int TaxRate;
            public int Default3dBankId;
        }
    }
}
