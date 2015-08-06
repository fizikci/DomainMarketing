namespace DealerSafe2.DTO.Enums
{
    public enum OrderStates
    {
        Basket,     // yeni sepet
        BasketCanceled,
        Order,      // ödemesi yapılmış
        Canceled,   // iptal edilmiş
        Preparing,  // kuyruğa joblar eklenmiş, hazırlanıyor
        Completed   // işi bitmiş, tamamlanmış
    }

    public enum CouponTypes
    {
        Money,
        Percentage
    }

    public enum MdfStates
    {
        None,
        Waiting,
        Confirmed,
        Rejected
    }

    public enum ProductPriceTypes
    {
        Create,
        Renew,
        Restore,
        Transfer,
        Upgrade
    }
}
