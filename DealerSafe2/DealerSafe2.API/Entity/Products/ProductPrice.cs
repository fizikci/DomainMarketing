using Cinar.Database;
using DealerSafe2.DTO.Enums;
namespace DealerSafe2.API.Entity.Products
{
    public class ProductPrice : BaseEntity, ICriticalEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public ProductPriceTypes ProductPriceType { get; set; }

        [ColumnDetail(Length = 12)]
        public string ProductId { get; set; }

        public int Price { get; set; }
        public int PurchasePrice { get; set; }
        public int DiscountPrice { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public string Currency { get; set; }
        public bool Recommended { get; set; }

        public Product Product() { return Provider.ReadEntityWithRequestCache<Product>(ProductId); }
    }
}