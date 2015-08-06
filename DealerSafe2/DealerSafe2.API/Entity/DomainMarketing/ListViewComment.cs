using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewCommentsToMember : BaseEntity
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string ToMemberId { get; set; }
        public string FromMemberId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}