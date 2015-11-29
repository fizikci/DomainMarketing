using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ListDMPredefinedMessageInfo : BaseEntityInfo
    {
        public bool IsDeleted { get; set; }
        public DateTime InsertDate { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
