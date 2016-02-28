using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class GetMarkRemindsInfo
    {
        public bool Process { get; set; }
        public List<MarkRemindDetail> MarkReminds { get; set; }
    }
    public class MarkRemindDetail
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ClassNumber { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
