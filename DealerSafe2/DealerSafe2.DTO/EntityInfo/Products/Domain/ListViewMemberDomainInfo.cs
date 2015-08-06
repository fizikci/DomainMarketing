using System;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo.Products.Domain
{
    public class ListViewMemberDomainInfo : BaseEntityInfo
    {
        public DateTime InsertDate { get; set; }
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string ProductName { get; set; }
        public DomainRenewalModes RenewalMode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DomainName { get; set; }
    }

   
}
