using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ReqError
    {
        public Exception Exception { get; set; }
        public int VirtualMachineId { get; set; }
        public string Source { get; set; }
    }
}
