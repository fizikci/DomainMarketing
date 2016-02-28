using DealerSafe.DTO.Enums;
using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqAddMembersAddressWithType: ReqAddMembersAddress
    {        
        [Description("Type (Bireysel/Kurumsal)")]
        public EnumMembersAddressType Type { get; set; }
    }
}
