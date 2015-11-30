using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqDMSaveItem :BaseRequest
    {
        public string DMItemId { get; set; }
        public string Type { get; set; }
        public string DomainName { get; set; }
        public string DMCategoryId { get; set; }
        public string LanguageId { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public string ExpiryDate { get; set; }
        public string Ownership { get; set; }
        public string PageRank { get; set; }
        public string VisibleInAdNetwork { get; set; }
        public string EnableDomainParking { get; set; }
        public string VerificationAsked { get; set; }
        public string IsPrivateSales { get; set; }
        public string Analytics { get; set; }
        public string AdSense { get; set; }
        public string Alexa { get; set; }
    }
}
