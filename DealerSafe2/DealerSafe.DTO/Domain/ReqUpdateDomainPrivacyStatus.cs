using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqUpdateDomainPrivacyStatus
    {
        [Description("Id of domain")]
        public int DomainId { get; set; }

        [Description("Status of new privacy protection, statuses : Disabled = 0, Enabled = 1, NoInfo = 2, EnabledByWhoisHider = 3")]
        public int ProtectionStatus { get; set; }
    }
}
