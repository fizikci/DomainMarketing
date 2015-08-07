using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewCommentsToMember : BaseEntity
    {
        public string ToFullName { get; set; }
        public string ToAvatar { get; set; }
        public string ToMemberId { get; set; }
        public string FromMemberId { get; set; }
        public string FromFullName { get; set; }
        public string FromAvatar { get; set; }
        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}