using System;
using System.Collections.Generic;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo
{
    public class MdfInfo : NamedEntityInfo
    {
        public string Description { get; set; }
        public string MdfText { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CountryId { get; set; }
        public string ResellerTypeId { get; set; }
        public DateTime AnnounceStartDate { get; set; }
        public DateTime AnnounceEndDate { get; set; }
        public int RebateRate { get; set; }
        public int RebateAmount { get; set; }
        public int LimitBottom { get; set; }
        public int LimitTop { get; set; }
        public int OrderNo { get; set; }
    }
}
