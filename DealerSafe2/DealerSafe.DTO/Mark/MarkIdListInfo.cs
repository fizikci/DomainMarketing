using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class MarkIdListInfo
    {
        public bool Process { get; set; }
        public List<MarkClassDetail> MarkClassList { get; set; }
    }
    public class MarkClassDetail
    {
        public int Id { get; set; }
        public string MarkName { get; set; }
        public int ClassNumber { get; set; }
    }
}
