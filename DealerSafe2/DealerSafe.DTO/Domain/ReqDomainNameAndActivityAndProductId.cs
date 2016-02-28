using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqDomainNameAndActivityAndProductId
    {
        public string DomainName { get; set; }
        public int ProductId { get; set; }
        public int[] Activities { get; set; }
    }
}
