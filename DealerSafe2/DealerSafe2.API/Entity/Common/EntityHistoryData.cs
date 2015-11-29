using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Common
{
    public class EntityHistoryData : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string EntityHistoryId { get; set; }
        public string Changes { get; set; }

        public EntityHistory EntityHistory() { return Provider.ReadEntityWithRequestCache<EntityHistory>(EntityHistoryId); }

    }
}