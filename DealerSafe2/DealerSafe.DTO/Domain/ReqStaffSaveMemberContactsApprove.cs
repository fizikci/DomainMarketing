using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain
{
    public class ReqStaffSaveMemberContactsApprove
    {
        public int contactId { get; set; }

        public bool isApproved { get; set; }

        public string sentTo { get; set; }

        public TypeOfApproving typeOfApproving { get; set; }

        public int SessionMemberId { get; set; }

        

    }
}
