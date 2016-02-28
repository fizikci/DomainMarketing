namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class ReqDomainNameAndActivity
    {
        [Description("name of domain")]
        public string DomainName { get; set; }

        [Description("Activity type")]
        public int Activity { get; set; }
    }
}
