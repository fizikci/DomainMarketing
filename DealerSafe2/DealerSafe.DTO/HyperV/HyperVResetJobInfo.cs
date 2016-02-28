using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class HyperVResetJobInfo
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public string Username { get; set; }
        public string Ip { get; set; }
        public DateTime Time { get; set; }
        public string ErrorDescription { get; set; }
        public string Description { get; set; }
    }
}
