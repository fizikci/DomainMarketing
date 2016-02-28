using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResTldPriceInformation
    {
        public decimal CompanyID { get; set; }
        public float Price { get; set; }
        public float Cost { get; set; }
        public float ExpiredPrice { get; set; }
        public float ExpiredCost { get; set; }
        public float RedemptionPrice { get; set; }
        public float RedemptionCost { get; set; }
        public float TransferPrice { get; set; }
        public float TransferCost { get; set; }
        public float IDNTransferPrice { get; set; }
        public float IDNTransferCost { get; set; }
        public float RenewPrice { get; set; }
        public float RenewCost { get; set; }
        public string PriceType { get; set; }
        public string QuantityType { get; set; }
        public float Tax { get; set; }
        public int InCampaign { get; set; }
        public float CampaignPrice { get; set; }
        public float CampaignPeriod { get; set; }
        public string CampaignDescription { get; set; }
        public string CampaignName { get; set; }
        public float OnTalepSelling { get; set; }
        public float SunRiseSelling { get; set; }
        public float LandRushSelling { get; set; }
    }
}
