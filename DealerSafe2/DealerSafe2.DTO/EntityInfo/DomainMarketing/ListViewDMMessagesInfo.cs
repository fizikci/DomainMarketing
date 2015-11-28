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
        public string FromMemberId { get; set; }
        public string FromMemberAvatar { get; set; }
        public string FromMemberFullname { get; set; }
        public string Tomemberid { get; set; }
        public string ToMemberAvatar { get; set; }
        public string ToMemberFullname { get; set; }
        public string InsertDate { get; set; }
    }
}
