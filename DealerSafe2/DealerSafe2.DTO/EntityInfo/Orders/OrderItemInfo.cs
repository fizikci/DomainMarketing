namespace DealerSafe2.DTO.EntityInfo
{
    public class OrderItemInfo : BaseEntityInfo
    {


        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public int Amount {get; set;}

        public string Unit { get; set; }

        public int Price {get; set;}

        public string Currency { get; set; }

        public int OrderNo { get; set; }

        public string DisplayName { get; set; }

        public string ProductPriceId { get; set; }

        public string ParentOrderItemId { get; set; }


        public OrderInfo Order { get; set; }

        public ProductInfo Product { get; set; }


    }
}
