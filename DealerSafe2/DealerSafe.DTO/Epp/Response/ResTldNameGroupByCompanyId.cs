 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Epp.Response
{
    public class ResTldNameGroupByCompanyId
    {
        public List<string> TldName { get; set; }
        public int CompanyId { get; set; }
    }
}
