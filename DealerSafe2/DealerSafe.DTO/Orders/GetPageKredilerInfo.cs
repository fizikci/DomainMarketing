using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class GetPageKredilerInfo
    {
        public bool Process { get; set; }

        public string Credit { get; set; }
        public double TotalCredit { get; set; }
        public double UsedCredit { get; set; }
        public double BlokeKredi { get; set; }
    }
}
