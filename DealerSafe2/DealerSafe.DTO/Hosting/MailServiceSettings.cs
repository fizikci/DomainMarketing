using System;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class MailServiceSettings
    {
        public string DomainName { get; set; }
        public EnmMailPanelType MailPanelType { get; set; }
        public long Limit { get; set; }
        public string IP { get; set; }
    }
}