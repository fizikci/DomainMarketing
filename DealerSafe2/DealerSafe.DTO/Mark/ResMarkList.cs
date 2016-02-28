using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ResMarkList
    {
        [Description("Mark ID")]
        public int ID { get; set; }

        [Description("Siparis No")]
        public int SiparisNo { get; set; }

        [Description("Surname LastName")]
        public string User { get; set; }

        [Description("Mark Product")]
        public string Product { get; set; }

        [Description("Mark Class")]
        public string MarkClass { get; set; }

        [Description("Mark Status")]
        public string MarkStatus { get; set; }

        [Description("Mark EndDate")]
        public string EndDate { get; set; }

        [Description("Mark ProcessStatus")]
        public EnmProcessStatus ProcessStatus { get; set; }
    }
}
