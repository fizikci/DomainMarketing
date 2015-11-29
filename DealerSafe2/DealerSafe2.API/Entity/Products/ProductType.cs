using System;
using Cinar.Database;
using DealerSafe2.API.Entity.LifeCycles;

namespace DealerSafe2.API.Entity.Products
{
    public class ProductType : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string LifeCycleId { get; set; }

        [ColumnDetail(Length = 12)]
        public string PropertySetId { get; set; }

        public LifeCycle LifeCycle() { return Provider.ReadEntityWithRequestCache<LifeCycle>(LifeCycleId); }

    }

    public class ListViewProductType : ProductType
    {
        public int ProductCount { get; set; }
        public string PropertySetName { get; set; }
        public string LifeCycleName { get; set; }
    }
}