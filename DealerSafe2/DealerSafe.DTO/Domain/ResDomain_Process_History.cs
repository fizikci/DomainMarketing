using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResDomain_Process_History
    {
        public string DomainName { get; set; }

        public int DomainPeriod { get; set; }

        public string DNS1 { get; set; }

        public string DNS2 { get; set; }

        public int Activity { get; set; }

        public int Status { get; set; }

        public string RegisterCompany { get; set; }

        public int DomainProcess { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime date { get; set; }
    }
}
