using DealerSafe.DTO.Enums;
using HyperV.DTO.EntityInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ServerExtendedInfo : CustomerVirtualMachineLongInfo
    {
        public int TotalDays { get; set; }
        public int RemainingDays { get; set; }
        public int RemainingPercent { get; set; }
        public bool IsExpired { get; set; }
        public string Uptime { get; set; }

        public bool PremiumSupport { get; set; }
        public bool Ddos { get; set; }
        public bool Firewall { get; set; }

        public DateTime? PremiumSupportStartDate { get; set; }
        public DateTime? PremiumSupportExpirationDate { get; set; }

        public DateTime? DdosStartDate { get; set; }
        public DateTime? DdosExpirationDate { get; set; }

        public DateTime? FirewallStartDate { get; set; }
        public DateTime? FirewallExpirationDate { get; set; }

        public int TotalIp { get; set; }
        public EnumHyperVServerStatus Status { get; set; }
    }
}
