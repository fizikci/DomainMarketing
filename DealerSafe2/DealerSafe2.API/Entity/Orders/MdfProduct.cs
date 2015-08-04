using Cinar.Database;
using DealerSafe2.API.Entity.Products;
using DealerSafe2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.Orders
{
    public class MdfProduct : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string MdfId { get; set; }
        [ColumnDetail(Length = 12)]
        public string ProductId { get; set; }

        public Mdf Mdf() { return Provider.ReadEntityWithRequestCache<Mdf>(MdfId); }
        public Product Product() { return Provider.ReadEntityWithRequestCache<Product>(ProductId); }

    }

    public class ListViewMdfProduct : MdfProduct
    {
        public string ProductName { get; set; }
    }
}
