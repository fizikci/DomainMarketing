using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResDomainWhoisAlternativeCheck
    {
        public string DomainStyle { get; set; }

        public string Name { get; set; }

        public string Tld { get; set; }

        public int TldId { get; set; }

        public float Price { get; set; }
    }
}
