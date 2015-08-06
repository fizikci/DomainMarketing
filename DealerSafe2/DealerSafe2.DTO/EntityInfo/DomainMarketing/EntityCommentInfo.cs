using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class EntityCommentInfo : BaseEntityInfo
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string ToMemberId { get; set; }
        public string FromMemberId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
