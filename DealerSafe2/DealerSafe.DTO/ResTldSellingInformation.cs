using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ResTldSellingInformation
    {
        public int ProductId { get; set; }
        public string TldName { get; set; }
        public float CampaignPrice { get; set; }
        public float CampaignPeriod { get; set; }
        public int BuyingCompanyId { get; set; }
        public int InCampaign { get; set; }
        public float Price { get; set; }
        public float OnTalepSelling { get; set; }
        public float SunRiseSelling { get; set; }
        public float LandRushSelling { get; set; } 
        public double UsdSelling { get; set; }
    }
}
