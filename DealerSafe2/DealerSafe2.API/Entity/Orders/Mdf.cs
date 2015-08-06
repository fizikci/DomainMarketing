using Cinar.Database;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Products;
using DealerSafe2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.Orders
{
    public class Mdf : NamedEntity
    {
        public string Description {get; set;}
        public string MdfText {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
        public string CountryId {get; set;}
        public string ResellerTypeId {get; set;}
        public DateTime AnnounceStartDate {get; set;}
        public DateTime AnnounceEndDate {get; set;}
        public int RebateRate {get; set;}
        public int RebateAmount {get; set;}
        public int LimitBottom {get; set;}
        public int LimitTop {get; set;}

        public Country Country() { return Provider.ReadEntityWithRequestCache<Country>(CountryId); }
        public ResellerType ResellerType() { return Provider.ReadEntityWithRequestCache<ResellerType>(ResellerTypeId); }


        public List<Product> Products;

        public void ReadProducts()
        {
            if(this.Products==null)
                this.Products = Provider.Database.ReadList<Product>("select * from Product where Id in (select ProductId from MdfProduct where MdfId = {0})", this.Id) ?? new List<Product>();
        }
    }

}
