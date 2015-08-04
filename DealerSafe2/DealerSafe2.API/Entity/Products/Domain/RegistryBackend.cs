using Cinar.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.Products.Domain
{
    public class RegistryBackend : NamedEntity
    {
        [ColumnDetail(Length = 100)]
        public string PanelUrl { get; set; }

        [ColumnDetail(Length = 30)]
        public string PanelUsername { get; set; }
        
        [ColumnDetail(Length = 30)]
        public string PanelPassword { get; set; }
    }
}