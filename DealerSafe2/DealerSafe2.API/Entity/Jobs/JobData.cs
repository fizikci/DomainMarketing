using System;

namespace DealerSafe2.API.Entity.Jobs
{
    public class JobData : BaseJobDetail
    {
        public string RequestUrl { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public int ProcessTime { get; set; }
    }
}