using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMFaq : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}