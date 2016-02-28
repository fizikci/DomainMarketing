using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResNewTldList
    {
        public int Id { get; set; }
        public string TldName { get; set; }
        public int SiraIndex { get; set; }
        public string SellingPrice { get; set; }
        public string Status { get; set; }
        public string DomainGruop { get; set; }
    }
}
