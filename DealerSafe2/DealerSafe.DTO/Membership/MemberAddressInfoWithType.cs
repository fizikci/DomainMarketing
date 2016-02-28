using DealerSafe.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class MembersAddressInfoWithType: MembersAddressInfo
    {
        public EnumMembersAddressType Type { get; set;}
    }
}
