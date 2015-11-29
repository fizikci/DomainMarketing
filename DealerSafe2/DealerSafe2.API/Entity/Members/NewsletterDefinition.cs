using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Members
{
    public class NewsletterDefinition : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string ApiId { get; set; }
        public string Content { get; set; }

        public ApiRelated.Api Api() { return Provider.ReadEntityWithRequestCache<ApiRelated.Api>(ApiId); }

    }
}