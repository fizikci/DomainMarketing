using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class StatisticsInfo
    {
        public string Percent { get; set; }
        public string Name { get; set; }
        public string UsedCount { get; set; }
        public string Max { get; set; }
        public string ItemKey { get; set; }
        public string Unit { get; set; }
    }
}