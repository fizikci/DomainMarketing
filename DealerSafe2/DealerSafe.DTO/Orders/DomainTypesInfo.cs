using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class DomainTypesInfo
    {
        public bool Process { get; set; }
        public List<DomainTypesDetail> DomainTypesList { get; set; }
        public class DomainTypesDetail
        {
            public int Id { get; set; }
            public int SiraIndex { get; set; }
            public int IsTrDomain { get; set; }
            public int IsSummaryDomain { get; set; }
            public string Name { get; set; }
            public int QueryCompanyID { get; set; }
            public int AlternativeCompanyID { get; set; }
            public string Whois { get; set; }
            public int IsInternic { get; set; }
            public int BuyingCompanyID { get; set; }
            public int TransferCompanyID { get; set; }
            public int CanBeTransferred { get; set; }
            public int SecretNecessary { get; set; }
            public int DocumentNecessary { get; set; }
            public int Status { get; set; }
            public int ExpirePeriod { get; set; }
            public int RedemptionPeriod { get; set; }
            public int IsPrivacyProtectionAllowed { get; set; }
            public int AllowedHireDuration { get; set; }
            public int IsIDN { get; set; }
            public int DomainClassType { get; set; }
            public int IsHireDurationContinious { get; set; }
            public int HireDurationStart { get; set; }
            public int HireDurationFinish { get; set; }
            public int HireDurationSpecific { get; set; }
            public string HireDurationCustom { get; set; }
            public int HireDurationControl { get; set; }
            public int OzelDurum { get; set; }
            public string OzetBilgi { get; set; }
            public string OzetBilgiDetay { get; set; }
            public string OzetBilgiTip { get; set; }
            public int AdSoyad { get; set; }
            public string DomainListingGroup { get; set; }
            public string DomainCountry { get; set; }
            public string DomainImageUrl { get; set; }
            public int IsVisibleOnWindow { get; set; }
            public string DomainLink { get; set; }
            public int TumUzantilar { get; set; }
            public int ExpirePeriodCompany { get; set; }
            public int RedemptionPeriodCompany { get; set; }
            public int MinLength { get; set; }
            public int MaxLength { get; set; }
            public int IsPremiumCapable { get; set; }
            public int QuickDomain { get; set; }
            public int ContactCompatibility { get; set; }
            public int CanLock { get; set; }
            public bool HostingCompany { get; set; }
            public int DeletionTimeFrame { get; set; }
            public int AutoRegister { get; set; }
        }
    }
}
