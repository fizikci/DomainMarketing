using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Common
{
    public class LanguageValue : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string LanguageId { get; set; }
        public string EntityName { get; set; }
        public string FieldName { get; set; }
        [ColumnDetail(Length = 12)]
        public string EntityId { get; set; }
        public string FieldValue { get; set; }

        public Language Language() { return Provider.ReadEntityWithRequestCache<Language>(LanguageId); }
    }
}
