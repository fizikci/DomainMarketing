using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqSaveMarkOrderDetail
    {
        public string MarkId { get; set; }
        public string CustomerDesc { get; set; }
        public string StaffDesc { get; set; }
        public string ddlDurum { get; set; }
        public string ddlTPEDurum { get; set; }
        public string HarcOdemeTarihi { get; set; }
    }
}
