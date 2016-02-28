using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class ResGetLogMethods
    {

        public List<LogList> LLogList { get; set; }

        public List<LogMethod> LLogMethod { get; set; }
    }

    public class LogList
    {
        public string LogDate { get; set; }

        public string LogTime { get; set; }

        public string MethodName { get; set; }

        public bool Successful { get; set; }

        public int MemberId { get; set; }

        public long ProcessTime { get; set; }

        public string Client { get; set; }

        public int Id { get; set; }
    
    }

    public class LogMethod
    {

        public string MethodName { get; set; }
    }
}
