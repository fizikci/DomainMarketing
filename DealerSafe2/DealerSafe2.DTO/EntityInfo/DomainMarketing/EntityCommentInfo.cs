using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class EntityCommentInfo : BaseEntityInfo
    {
        public string ToFullName { get; set; }
        public string ToAvatar { get; set; }
        public string ToMemberId { get; set; }
        public string FromMemberId { get; set; }
        public string FromFullName { get; set; }
        public string FromAvatar { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
