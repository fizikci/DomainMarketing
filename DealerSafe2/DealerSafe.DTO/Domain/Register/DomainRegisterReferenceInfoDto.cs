using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class DomainRegisterReferenceInfoDto
    {
        public int Id { get; set; }
        public int DomainId { get; set; }
        public int OrderDetailId { get; set; }
        public int MemberId { get; set; }
        public int RegisterType { get; set; }
    }
}
