namespace DealerSafe2.DTO.EntityInfo
{
    public class ProductPriceInfo : BaseEntityInfo
    {
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public int Amount { get; set; }
        public string Unit {get; set;}
        public string Currency {get; set;}
        public bool Recommended { get; set; }
    }
}
