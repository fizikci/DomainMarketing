using System;
using Cinar.Database;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Common
{
    public class EntityHistory : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 10)]
        public EntityOperation Operation { get; set; }

        public string EntityName { get; set; }
        [ColumnDetail(Length = 12)]
        public string EntityId { get; set; }
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }

        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }
    }
}
