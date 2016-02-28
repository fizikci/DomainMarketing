using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class HostingLogInfo
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public DateTime ProcessTime { get; set; }
    }
}
