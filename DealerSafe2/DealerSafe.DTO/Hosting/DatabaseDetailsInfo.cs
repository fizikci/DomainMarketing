using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class DatabaseDetailsInfo
    {
        public string DbName { get; set; }
        public string DbUserNames { get; set; }
        public int DbUserCount { get; set; }
        public int DbSize { get; set; }
    }
}