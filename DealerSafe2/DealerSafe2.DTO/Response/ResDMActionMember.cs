using System.Linq;
using DealerSafe2.DTO.EntityInfo.DomainMarketing;
using System.Collections.Generic;

namespace DealerSafe2.DTO.Response
{
    public class ResDMAuctionMember
    {

        public List<DMAuctionMemberInfo> Auctions { get; set; }
        public int rowCount { get; set; }
    }
}

