using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqSaveMarkRequestDetail
    {
        public string RequestID { get; set; }
        public string CustomerNotes { get; set; }
        public string HazirCevap { get; set; }
        public string ReviewofResultStatus { get; set; }
        public string StaffNotes { get; set; }
        public string RequestStatus { get; set; }
        public string ProcessStatus { get; set; }
        public string ContactNextDate { get; set; }
    }
}
