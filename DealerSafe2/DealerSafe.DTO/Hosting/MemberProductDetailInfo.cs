using System;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class MemberProductDetailInfo
    {
        public int Id { get; set; }
        public int? EnmVariable { get; set; }
        public string Name { get; set; }
        public string NameForWeb { get; set; }
        public int? Value { get; set; }
        public int? ItemUsedValue { get; set; }
        public string ItemValueStr { get; set; }
        public EnmPROPS EnmProp
        {
            get { return (EnmPROPS)(EnmVariable ?? 0); }
        }
        public int DetailId { get; set; }
    }
}