using System;
using System.Collections.Generic;
using DealerSafe2.DTO.Enums;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class DMAuctionMemberInfo:BaseEntityInfo
    {

        public string DMAuctionId { get; set; }

        public DMItemTypes Type { get; set; }

        public int BiggestBid { get; set; }

        public string DomainName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MemberId { get; set; }
    }
}
