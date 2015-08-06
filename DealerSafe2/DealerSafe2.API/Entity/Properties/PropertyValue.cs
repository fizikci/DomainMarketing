using Cinar.Database;
namespace DealerSafe2.API.Entity.Properties
{
    public class PropertyValue : BaseEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 30)]
        public string EntityName { get; set; }
        [ColumnDetail(Length = 12)]
        public string EntityId { get; set; }
        [ColumnDetail(Length = 12)]
        public string PropertyId { get; set; }
        public string Value { get; set; }

        public Property Property() { return Provider.ReadEntityWithRequestCache<Property>(PropertyId); }

    }

    public class ListViewPropertyValue : PropertyValue
    {
        public string PropertyGroupName { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string PropertyOptions { get; set; }
        public string PropertyDefaultValue { get; set; }
        public int OrderNo { get; set; }
    }
}