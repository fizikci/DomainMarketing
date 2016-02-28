using DealerSafe.DTO.Enums;
using HyperV.DTO.EntityInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ServerInfoAdmin : CustomerVirtualMachineShortInfo
    {
        public int MemberId { get; set; }
        public int OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool IsExpired { get; set; }
        public int ServerId { get; set; }
        public string Username { get; set; }
        public EnumHyperVServerStatus Status { get; set; }

        public int Generation { get; set; }
        public decimal Price { get; set; }
    }
}
