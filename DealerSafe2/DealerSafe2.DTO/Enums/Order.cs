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

    /// <summary>
    /// Bir ürün oluşturulup müşteriye verildiği zaman "Active" statüsündedir.
    /// Ürün StartDate-EndDate süresi boyunca Active statüsünde kalır.
    /// Ürünün kullanım süresi dolduğunda WaitingForRenewal statüsüne alınır.
    /// </summary>

    public enum LifeCyclePhases
    {
        None,
        Active,
        WaitingForRenewal,
        WaitingForRestore,
        Deleted,
        BackupAvailable
    }
}
