using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Members
{
    public class Role : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string ApiId { get; set; }

        public ApiRelated.Api Api() { return Provider.ReadEntityWithRequestCache<ApiRelated.Api>(ApiId); }

    }

    public class ListViewRole : BaseEntity
    {
        public string Name { get; set; }
        public string ApiId { get; set; }
        public int RightCount { get; set; }
        public int MemberCount { get; set; }
    }
}