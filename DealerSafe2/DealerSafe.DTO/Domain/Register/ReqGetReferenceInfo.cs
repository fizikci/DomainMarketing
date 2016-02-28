using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqGetReferenceInfo
    {
        public int DomainId { get; set; }
        public int OrderDetailId { get; set; }
    }
}
