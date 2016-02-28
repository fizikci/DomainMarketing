using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class DomainTypeInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TumUzantilar { get; set; }
        public int IsTrDomain { get; set; }
        public int IsNewTld { get; set; }
        public int IsIDN { get; set; }
        public int IsSummaryDomain { get; set; }
        public int CanBeTransferred { get; set; }
        public int IsVisibleOnWindow { get; set; }
        public int Status { get; set; }
        public int AdSoyad { get; set; }
        public int InCamping { get; set; }

        // 3.2.2015
        public int FakeCampaign { get; set; }
        public int IsBold { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}
