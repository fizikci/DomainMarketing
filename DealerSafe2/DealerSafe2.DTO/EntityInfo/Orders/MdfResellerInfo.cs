using System;
using System.Collections.Generic;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo
{
    public class MdfResellerInfo : NamedEntityInfo
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RebateRate { get; set; }
        public int RebateAmount { get; set; }
        public int LimitBottom { get; set; }
        public string MdfId { get; set; }
        public MdfStates State { get; set; }
        public int CreditsToRefund { get; set; }
    }
}
