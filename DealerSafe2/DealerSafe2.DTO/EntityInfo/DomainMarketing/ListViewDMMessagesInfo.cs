using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ListViewDMMessagesInfo : BaseEntityInfo
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderMemberId { get; set; }
        public string SenderMemberAvatar { get; set; }
        public string SenderMemberFullName { get; set; }
        public string ToMemberId { get; set; }
        public string ToMemberAvatar { get; set; }
        public string ToMemberFullName { get; set; }
        public string InsertDate { get; set; }
    }
}
