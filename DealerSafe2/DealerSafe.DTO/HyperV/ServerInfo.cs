using DealerSafe.DTO.Enums;
using HyperV.DTO.EntityInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ServerInfo: CustomerVirtualMachineShortInfo
    {
        public long StartDateUnix { get; set; }
        public long ExpirationDateUnix { get; set; }        
        public int ServerId { get; set; }
        public bool IsExpired { get; set; }
        public EnumHyperVServerStatus Status { get; set; }

        public string EncodedId { get; set; }
    }
}
