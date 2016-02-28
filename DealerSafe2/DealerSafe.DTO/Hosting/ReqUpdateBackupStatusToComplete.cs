using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Hosting
{
    public class ReqUpdateBackupStatusToComplete
    {
        public int OrderDetailId { get; set; }
        public int AdminMemberId { get; set; }
    }
}
