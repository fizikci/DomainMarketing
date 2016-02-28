using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class MemberProductDetailsInfo
    {
        public int Id { get; set; }
        public int MemberProductId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemValue { get; set; }
        public int ItemUsedValue { get; set; }
        public string ItemValueStr { get; set; }
        public string Description { get; set; }
        public int EnmProp { get; set; }
    }
}
