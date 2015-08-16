using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.Request
{
    public class ResAucUpdate
    {
        public string DomainName { get; set; }
        public string DMItemId { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public string Comments { get; set; }
    }

}
