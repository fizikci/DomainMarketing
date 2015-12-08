using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqDMSaveItem :BaseRequest
    {
        public string Id { get; set; }
        public DMItemTypes Type { get; set; }
        public string DomainName { get; set; }
        public string DMCategoryId { get; set; }
        public string LanguageId { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Ownership { get; set; }
        public int BuyItNowPrice { get; set; }
        public int PageRank { get; set; }
        public bool VisibleInAdNetwork { get; set; }
        public bool EnableDomainParking { get; set; }
        public bool VerificationAsked { get; set; }
        public bool IsPrivateSale { get; set; }
        public string Analytics { get; set; }
        public string AdSense { get; set; }
        public string Alexa { get; set; }
    }
}
