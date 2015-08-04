using System.Collections.Generic;

namespace DealerSafe2.DTO.EntityInfo
{
    public class ProductInfo : NamedEntityInfo
    {
        public string GroupName { get; set; }
        public bool IsFeatured { get; set; }
        public int UserTrustLevel { get; set; }

        public List<ProductPriceInfo> ListProductPrice { get; set; }
        public List<ViewPropertyValueInfo> Properties { get; set; }
    }
}
