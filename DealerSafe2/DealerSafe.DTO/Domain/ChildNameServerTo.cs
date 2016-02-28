using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ChildNameServerTo
    {
        public int Id { get; set; }
        public decimal DomainID { get; set; }
        public decimal MemberID { get; set; }
        public string CNSName { get; set; }
        public string IPAdres { get; set; }
        public string NicTrTicketNumber { get; set; }
    }
}
