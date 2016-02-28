using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqMarkAddClass
    {
        public int MarkID { get; set; }
        public List<int> ClassList { get; set; }
    }
}
