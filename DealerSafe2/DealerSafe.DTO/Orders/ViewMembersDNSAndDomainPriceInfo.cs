using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ViewMembersDNSAndDomainPriceInfo
    {
        public bool Process { get; set; }
        public List<ViewMembersDNSAndDomainPriceDetail> ViewMembersDNSAndDomainPriceList { get; set; }

        public class ViewMembersDNSAndDomainPriceDetail
        {
            public int ID { get; set; }
            public string DomainName { get; set; }
            public int DomainPeriod { get; set; }
            public double Price { get; set; }
            public double ExpiredPrice { get; set; }
            public double RedemptionPrice { get; set; }
            public double TransferPrice { get; set; }
            public double RenewPrice { get; set; }
            public int InCampaign { get; set; }
            public double CampaignPrice { get; set; }
            public double CampaignPeriod { get; set; }
            public int OrderID { get; set; }
            public int MemberID { get; set; }
            public int ProductID { get; set; }
            public int isIDN { get; set; }
            public int Activity { get; set; }
            public int DomainProcess { get; set; }
            public string CreationDate { get; set; }
            public string ExpirationDate { get; set; }
        }
    }
}
