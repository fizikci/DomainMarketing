using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark.Logs
{
    public class LogsInfo
    {
        public int MemberID { get; set; }
        public int StaffID { get; set; }
        public enmBrandLogType BrandLogType { get; set; }
        public enmProcessStatus ProcessStatus { get; set; }
        public int TargetID { get; set; }
        public string ProcessDesc { get; set; }
        public string UserAgent { get; set; }
        public string Browser { get; set; }
        public string ClientIP { get; set; }
        public string CreateDate { get; set; }
        public LogDataDetail LogData { get; set; }
    }
    public class LogDataDetail
    {
        public Dictionary<string, string> RequetXml { get; set; }
        public Dictionary<string, string> ResponseXml { get; set; }
        public string CreateDate { get; set; }
    }
    public enum enmBrandLogType
    {
        BrandOrder, BrandRequest
    }
    public enum enmProcessStatus
    {
        Success = 1, Error = 0
    }
}
