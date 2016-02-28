using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class AddMembersAddressInfo
    {
        public bool Process { get; set; }

        [Description("Id of the member's address")]
        public int Id { get; set; }
    }
}
