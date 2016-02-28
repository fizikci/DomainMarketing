using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class NictrNewQueueParams
    {
        public string Name { get; set; }
        public Object Val { get; set; }
    }
    public class NictrNewQueue
    {
        public string FnkName { get; set; }
        public List<NictrNewQueueParams> FnKParams { get; set; }
    }
}
