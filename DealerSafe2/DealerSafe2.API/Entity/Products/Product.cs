using Cinar.Database;
using DealerSafe2.API.Entity.Properties;
using System.Collections.Generic;

namespace DealerSafe2.API.Entity.Products
{
    public class Product : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length=12)]
        public string ParentProductId { get; set; }
        [ColumnDetail(Length = 12)]
        public string ProductTypeId { get; set; }
        [ColumnDetail(Length = 12)]
        public string SupplierId { get; set; }

        public int SupplierPriority { get; set; }
        public bool IsFeatured { get; set; }
        public string SupplierProductRefNo { get; set; }
        public int UserTrustLevel { get; set; }

        [ColumnDetail(Length = 12)]
        public string LifeCycleId { get; set; }
        [ColumnDetail(Length = 12)]
        public string PropertySetId { get; set; }

        public Product ParentProduct() { return Provider.ReadEntityWithRequestCache<Product>(ParentProductId); }
        public ProductType ProductType() { return Provider.ReadEntityWithRequestCache<ProductType>(ProductTypeId); }
        public Supplier Supplier() { return Provider.ReadEntityWithRequestCache<Supplier>(SupplierId); }

        public List<PropertyValue> GetPropertyValues()
        {
            return Provider.Database.ReadList<PropertyValue>("select * from PropertyValue where EntityName='Product' AND EntityId={0}", this.Id);
        }
    }

    public class ListViewProduct : BaseEntity
    {
        public string Name { get; set; }
        public string ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int SupplierPriority { get; set; }
        public bool IsFeatured { get; set; }
    }

    public class ViewProduct : Product
    {
        public string ParentProductName { get; set; }
        public string ProductTypeName { get; set; }
        public string SupplierName { get; set; }
    }
}