using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class MarkOrderLogInfo
    {
        public List<LogDetail> Logs { get; set; }
        public class LogDetail
        {
            public int Id { get; set; }
            public int MemberID { get; set; }
            public int StaffID { get; set; }
            public string StaffName { get; set; }
            public enmBrandLogType BrandLogType { get; set; }
            public int ProcessStatus { get; set; }
            public int TargetID { get; set; }
            public string ProcessDesc { get; set; }
            public string UserAgent { get; set; }
            public string Browser { get; set; }
            public string ClientIP { get; set; }
            public string RequestXML { get; set; }
            public string ResponseXML { get; set; }
            public DateTime CreateDate { get; set; }
        }
    }
    public enum enmBrandLogType
    {
        BrandOrder, BrandRequest
    }
}
