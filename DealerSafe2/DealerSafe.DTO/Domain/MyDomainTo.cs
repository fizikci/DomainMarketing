using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public enum EnmPrivacyProtection { Disabled = 0, Enabled = 1, NoInfo = 2, EnabledByWhoisHider = 3 }
    public enum EnmDomainContactType { Registry = 1, Admin = 2, Tech = 3, Billing = 4, all = 5 }

    public class MyDomainTo
    {
        public MyDomainTo ()
	    {
            RegistCompID = "3";
            MemberID = 0;
            IsPrivacyProtected = 0;
            DirectiOrderID = 0;
            domainPeriod = 0;
            UzantiID = 0;
            ApplicationType = -1;
            yil = 0;
            sure = 0;
            inCampaign = 0;
            CompaignPrice = 0;
            CampaignPeriod = 0;
            tax = 0;
            price = 0;
            RedemptionPrice = 0;
            ExpiredPrice = 0;
            RenewPrice = 0;
	    }

        public string domainID { get; set; }
        public string tarih { get; set; }
        public string gunVEay { get; set; }
        public string OrderID { get; set; }
        public string DomainName { get; set; }
        public string Activity { get; set; }
        public string EndDate { get; set; }
        public string RegistComp { get; set; }
        public string DNS1  { get; set; }
        public string DNS2  { get; set; }
        public string DNS3  { get; set; }
        public string DNS4  { get; set; }
        public string DNSID { get; set; }
        public string SelectedDNS { get; set; }
        public string ContactIDRegistry { get; set; }
        public string ContactIDAdmin { get; set; }
        public string ContactIDTech { get; set; }
        public string ContactIDBilling { get; set; }
        public int RefContId { get; set; }
        public string ProductID { get; set; }
        public string activity { get; set; }
        public string RegistCompID { get; set; }
        public string priceType { get; set; }
        public string quantityType { get; set; }
        public string DomainStatus { get; set; }
        public string DomainProcess { get; set; }
        public string DirectiCustomerID { get; set; }
        public int MemberID { get; set; }
        public string Secret { get; set; }
        public string NicTrDNSTciketNumber { get; set; }
        public string NictrTicketNum { get; set; }
        public int IsPrivacyProtected { get; set; }
        public int DirectiOrderID { get; set; }
        public int domainPeriod { get; set; }
        public int UzantiID { get; set; }
        public int ApplicationType { get; set; }
        public int yil { get; set; }
        public int sure { get; set; }

        public int inCampaign { get; set; }
        public double CompaignPrice { get; set; }
        public int CampaignPeriod { get; set; }

        public double tax { get; set; }
        public double price { get; set; }
        public double RedemptionPrice { get; set; }
        public double ExpiredPrice { get; set; }
        public double RenewPrice { get; set; }

        public DateTime CreationDate;
        public DateTime ExpirationDate;

        public int AutoRegisterResult;

        //enmContactCompatibility BCIT MemberContacts altinda
        public int ContactCompatibility;
    }
}
