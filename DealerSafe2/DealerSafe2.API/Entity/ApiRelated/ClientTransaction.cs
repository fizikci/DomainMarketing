using System;
using Cinar.Database;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Orders
{
    public class ClientTransaction : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string ClientId { get; set; }
        public string RelatedEntityName { get; set; }
        [ColumnDetail(Length = 12)]
        public string RelatedEntityId { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }

    public class ListViewClientTransaction : MemberTransaction
    {
        public string ClientName { get; set; }
    }
}