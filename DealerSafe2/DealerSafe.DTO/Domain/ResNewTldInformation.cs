using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResNewTldInformation
    {
        public enum StatusEnum
        {
            GeneralAvailability = 1,
            NotAvailable = 2
        }

        public int TldRegCompanyId { get; set; }

        public string TldCategory { get; set; }

        public string TldImageUrl { get; set; }

        public int TldPopularitePercent { get; set; }

        public string InvestmentValue { get; set; }

        public string Description { get; set; }

        public string Description1 { get; set; }

        public string DomainClass { get; set; }

        public int CharacterMin { get; set; }

        public int CharacterMax { get; set; }

        public bool IDNSupport { get; set; }

        public bool WhoisProtection { get; set; }

        public int BuyingMinYear { get; set; }

        public int BuyingMaxYear { get; set; }

        public bool SpecialConditions { get; set; }

        public decimal OnTalepBuying { get; set; }

        public float OnTalepSelling { get; set; }

        public bool OnTalep { get; set; }

        public DateTime SunRiseStartDate { get; set; }

        public DateTime SunRiseEndDate { get; set; }

        public decimal SunRiseBuying { get; set; }

        public float SunRiseSelling { get; set; }

        public bool SunRise { get; set; }

        public DateTime LandRushStartDate { get; set; }

        public DateTime LandRushEndDate { get; set; }

        public decimal LandRushBuying { get; set; }

        public float LandRushSelling { get; set; }

        public bool LandRush { get; set; }

        public DateTime GeneralAvalibleStartDate { get; set; }

        public float GeneralAvalibleSelling { get; set; }

        public int IsCampaignSelling { get; set; }

        public float GeneralAvalibleCampaignSelling { get; set; }

        public int AvailabilityStatus { get; set; }
    }


    public class TldPremiumDomain
    {
        public string DomainName { get; set; }
        public float PurchasePrice { get; set; }
    }
}
