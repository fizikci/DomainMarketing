using DealerSafe2.API.Entity.Products.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Api.Library
{
    public static class DomainUtility
    {
        public static Product GetZoneFromDomainName(string domainName)
        {
            var extension = GetDomainExtension(domainName);
            return Provider.Database.Read<Product>("Id={0}", extension);
        }

        public static string GetDomainExtension(string domainName)
        {
            return domainName.Substring(domainName.IndexOf('.'));
        }
    }
}