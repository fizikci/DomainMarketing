using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Epp.Response
{
    public class ReqTldInformationSave
    {
        public string TldName { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Description1 { get; set; }

        public int TldPopularitePercent { get; set; }

        public string InvestmentValue { get; set; }

        public string TldType { get; set; }

        public string DomainClass { get; set; }

        public int CharacterMin { get; set; }

        public int CharacterMax { get; set; }

        public bool IDNSupport { get; set; }

        public bool WhoisProtection { get; set; }

        public int BuyingMinYear { get; set; }

        public int BuyingMaxYear { get; set; }

        public bool OnTalep { get; set; }

        public decimal OnTalepBuying { get; set; }

        public float OnTalepSelling { get; set; }

        public bool SunRise { get; set; }

        public decimal SunRiseBuying { get; set; }

        public float SunRiseSelling { get; set; }

        public DateTime SunRiseStartDate { get; set; }

        public DateTime SunRiseEndDate { get; set; }

        public bool LandRush { get; set; }

        public decimal LandRushBuying { get; set; }

        public float LandRushSelling { get; set; }

        public DateTime LandRushStartDate { get; set; }

        public DateTime LandRushEndDate { get; set; }

        public DateTime GeneralAvalibleStartDate { get; set; }

        public int CompanyId { get; set; }
    }
}
