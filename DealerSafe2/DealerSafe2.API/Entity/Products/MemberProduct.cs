using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.API.Entity.Products;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Products
{
    public class MemberProduct : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string OrderItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool Created { get; set; }

        public OrderItem OrderItem() { return Provider.ReadEntityWithRequestCache<OrderItem>(OrderItemId); }
    }
}