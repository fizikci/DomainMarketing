namespace DealerSafe2.API.Entity.Common
{
    public class ExchangeRate : BaseEntity
    {
        public string Currency { get; set; }
        public int PriceTL { get; set; }
    }
}