using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class MembersDNSOtherCompanyTo
    {
        public int Id { get; set; }
        public decimal MemberId { get; set; }
        public string DomainName { get; set; }
        public string Dns1 { get; set; }
        public string Dns2 { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
