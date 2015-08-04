using System;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo.Products.SSL
{
    public class ListViewMemberSSLInfo : BaseEntityInfo
    {
        public DateTime InsertDate { get; set; }
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public SSLStates State { get; set; }
        public string DomainName { get; set; }
    }
}
