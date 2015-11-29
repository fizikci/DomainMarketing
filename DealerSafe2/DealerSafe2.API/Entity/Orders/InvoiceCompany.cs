using System;

namespace DealerSafe2.API.Entity.Orders
{
    public class InvoiceCompany : NamedEntity, ICriticalEntity
    {
        public bool IsDefault { get; set; }
        public string PGUsername { get; set; }
        public string PGPassword { get; set; }
        public string PGApiKey { get; set; }
    }
}