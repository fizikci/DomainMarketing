using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResNewTldAvailable
    {
        public string DomainName { get; set; }

        public float MinPrice { get; set; }

        public int IsCampaignPrice { get; set; }

        public float CampaignPrice { get; set; }

        public Statu Status { get; set; }

        public TldStatuser TldStatu { get; set; }

        public int AvailabilityStatus { get; set; }

        public float OnTalepSellingPrice { get; set; }
        public string Reason { get; set; }
    }

    public enum TldStatuser
    {
        NotGeneralAvalible = 1,
        GeneralAvalible = 2
    }


    public enum Statu
    {
        Uygun = 0,
        Whois = 1
    }

}
