using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqNewGtldDelete
    {
        public int TldId { get; set; }

        public string domainName { get; set; }
    }
}
