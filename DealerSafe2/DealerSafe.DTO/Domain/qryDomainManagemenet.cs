using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class qryDomainManagemenet
    {
        public int Id { get; set; }
        public int SiraIndex { get; set; }
        public int isTrDomain { get; set; }
        public int isSummaryDomain { get; set; }
        public string Name { get; set; }
        public int QueryCompanyID { get; set; }
        public int AlternativeCompanyID { get; set; }
        public string Whois { get; set; }
        public int BuyingCompanyID { get; set; }
        public int TransferCompanyID { get; set; }
        public short CanBeTransferred { get; set; }
        public short SecretNecessary { get; set; }
        public short DocumentNecessary { get; set; }
        public short Status { get; set; }
        public int ExpirePeriod { get; set; }
        public int RedemptionPeriod { get; set; }
        public short IsPrivacyProtectionAllowed { get; set; }
        public int AllowedHireDuration { get; set; }
        public float Price { get; set; }
        public float ExpiredPrice { get; set; }
        public float RedemptionPrice { get; set; }
        public float TransferPrice { get; set; }
        public float RenewPrice { get; set; }
        public string PriceType { get; set; }
        public string QuantityType { get; set; }
        public float Tax { get; set; }
        public short InCampaign { get; set; }
        public float CampaignPrice { get; set; }
        public float CampaignPeriod { get; set; }
        public decimal DomainPriceID { get; set; }
        public float Cost { get; set; }
        public float RedemptionCost { get; set; }
        public float TransferCost { get; set; }
        public float IDNTransferPrice { get; set; }
        public float IDNTransferCost { get; set; }
        public float RenewCost { get; set; }
        public float ExpiredCost { get; set; }
        public int IsInternic { get; set; }
        public int isIDN { get; set; }
        public short IsHireDurationContinious { get; set; }
        public int DomainClassType { get; set; }
        public int HireDurationFinish { get; set; }
        public int HireDurationStart { get; set; }
        public int HireDurationSpecific { get; set; }
        public string HireDurationCustom { get; set; }
        public short HireDurationControl { get; set; }
        public int OzelDurum { get; set; }
        public string OzetBilgi { get; set; }
        public string OzetBilgiDetay { get; set; }
        public string OzetBilgiTip { get; set; }
        public short AdSoyad { get; set; }
        public string DomainListingGroup { get; set; }
        public string DomainCountry { get; set; }
        public string DomainImageUrl { get; set; }
        public short IsVisibleOnWindow { get; set; }
        public string DomainLink { get; set; }
        public int TumUzantilar { get; set; }
        public short ExpirePeriodCompany { get; set; }
        public short RedemptionPeriodCompany { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public byte IsPremiumCapable { get; set; }
        public byte QuickDomain { get; set; }
        public short ContactCompatibility { get; set; }
        public int CanLock { get; set; }
        public bool HostingCompany { get; set; }
        public int DeletionTimeFrame { get; set; }
        public string DocumentUrl { get; set; }


        public string SorgulamaTxt { get; set; }
        public string AlternatifTxt { get; set; }
        public string SatinAlmaTxt { get; set; }
        public string TransferTxt { get; set; }
        public string StatusTxt { get; set; }
    }
}
