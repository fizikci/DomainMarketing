namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class ReqMemberHostAndActivity
    {
        [Description("Host IDs of")]
        public int HostId { get; set; }

        [Description("Activity type")]
        public int Activity { get; set; }
    }
}
