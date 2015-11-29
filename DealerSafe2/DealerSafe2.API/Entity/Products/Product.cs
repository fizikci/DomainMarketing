using System;
using Cinar.Database;
using DealerSafe2.API.Entity.Properties;
using System.Linq;
using System.Collections.Generic;
using DealerSafe2.API.Entity.LifeCycles;

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

        public Product ParentProduct() { return Provider.ReadEntityWithRequestCache<Product>(ParentProductId); }
        public ProductType ProductType() { return Provider.ReadEntityWithRequestCache<ProductType>(ProductTypeId); }
        public Supplier Supplier() { return Provider.ReadEntityWithRequestCache<Supplier>(SupplierId); }
        public LifeCycle LifeCycle() {
            if (!LifeCycleId.IsEmpty())
                return Provider.ReadEntityWithRequestCache<LifeCycle>(LifeCycleId);
            else if (!Supplier().LifeCycleId.IsEmpty())
                return Supplier().LifeCycle();
            else if (!ProductType().LifeCycleId.IsEmpty())
                return ProductType().LifeCycle();

            return null;
        }

        public string GetProperty(string propertyName)
        {
            var prop = 
                GetProductProperties(Id, ProductTypeId, SupplierId)
                .FirstOrDefault(p => p.PropertyName == propertyName);
            if (prop == null)
                return null;

            return prop.Value.IsEmpty() ? prop.PropertyDefaultValue : prop.Value;
        }

        public List<ListViewPropertyValue> GetProperties()
        {
            return GetProductProperties(Id, ProductTypeId, SupplierId);
        }

        public static List<ListViewPropertyValue> GetProductProperties(string productId, string productTypeId, string supplierId)
        {
            var propertSetId = Provider.Database.GetString("select PropertySetId from Supplier where Id = {0}", supplierId);
            if (propertSetId.IsEmpty())
                propertSetId = Provider.Database.GetString("select PropertySetId from ProductType where Id = {0}", productTypeId);
            if (propertSetId.IsEmpty())
                throw new Exception("PropertySet is undefined. Set it for either ProductType or Supplier");

            List<Property> defaultValues = Provider.Database.ReadList<Property>("select * from Property WHERE PropertySetId={0}", propertSetId);
            List<ListViewPropertyValue> productTypeProps = Provider.Database.ReadList<ListViewPropertyValue>("select * from ListViewPropertyValue WHERE EntityName={0} AND EntityId={1}", "ProductType", productTypeId);
            List<ListViewPropertyValue> supplierProps = Provider.Database.ReadList<ListViewPropertyValue>("select * from ListViewPropertyValue WHERE EntityName={0} AND EntityId={1}", "Supplier", supplierId);
            List<ListViewPropertyValue> productProps = Provider.Database.ReadList<ListViewPropertyValue>("select * from ListViewPropertyValue WHERE EntityName={0} AND EntityId={1}", "Product", productId);

            List<ListViewPropertyValue> res = new List<ListViewPropertyValue>();
            foreach (var d in defaultValues)
            {
                ListViewPropertyValue pv = productProps.FirstOrDefault(pp => pp.PropertyId == d.Id);
                if (pv == null)
                    pv = supplierProps.FirstOrDefault(sp => sp.PropertyId == d.Id);
                if (pv == null)
                    pv = productTypeProps.FirstOrDefault(ptp => ptp.PropertyId == d.Id);

                if (pv == null)
                    pv = new ListViewPropertyValue
                    {
                        EntityId = productId.IsEmpty() ? (supplierId.IsEmpty() ? productTypeId : supplierId) : productId,
                        EntityName = productId.IsEmpty() ? (supplierId.IsEmpty() ? "ProductType" : "Supplier") : "Product",
                        OrderNo = d.OrderNo,
                        PropertyDefaultValue = d.DefaultValue,
                        PropertyGroupName = d.GroupName,
                        PropertyId = d.Id,
                        PropertyName = d.Name,
                        PropertyOptions = d.Options,
                        PropertyType = d.PropType
                    };
                res.Add(pv);
            }
            return res;
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