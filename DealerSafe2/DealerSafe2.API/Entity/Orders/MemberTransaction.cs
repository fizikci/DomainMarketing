using System;
using Cinar.Database;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Orders
{
    public class MemberTransaction : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
        public string RelatedEntityName { get; set; }
        [ColumnDetail(Length = 12)]
        public string RelatedEntityId { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }

    public class ListViewMemberTransaction : MemberTransaction
    {
        public string MemberName { get; set; }
    }
}