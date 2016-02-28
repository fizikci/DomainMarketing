using System;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Hosting
{
      [Serializable]
    public class HostingProperty
    {
        public int ID { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? ItemValue { get; set; }
        public int? ItemUsedValue { get; set; }
        public string ItemValueStr { get; set; }
        public string Description { get; set; }
        public int? IntEnmProp { get; set; }
        public EnmPROPS EnmProp { get { return (EnmPROPS)(IntEnmProp ?? 0); } }
    }
}