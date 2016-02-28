using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class DomainLandingPageTo
    {
        public int Id { get; set; }

        /// <summary>
        /// Domain Type iliskisi
        /// </summary>
        public int DomainTypeId { get; set; }

        public string Kategori { get; set; }

        /// <summary>
        /// .futbol seklinde girilecek
        /// </summary>
        public string Ad { get; set; }

        public bool IsOzelKosul { get; set; }

        public bool UcretliOnTalep { get; set; }
        public bool UcretsizOnTalep { get; set; }
        public double OnTalepMaliyet { get; set; }
        public double OnTalepSatis { get; set; }

        public DateTime SunRiseTarih { get; set; }
        public double SunRiseMaliyet { get; set; }
        public double SunRiseSatis { get; set; }

        public double LandRushMaliyet { get; set; }
        public double LandRushSatis { get; set; }

        public double GenelMaliyet { get; set; }
        public double GenelSatis { get; set; }

        public bool IdnDestegi { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public bool ContactDuzenleme { get; set; }
        public bool WhoisKorumasi { get; set; }

        public bool OzelYenileme { get; set; }
        public double OzelYenilemeMaliyet { get; set; }
        public double OzelYenilemeSatis { get; set; }

        public bool DnsDestegi { get; set; }
        public int MinKayitSuresi { get; set; }
        public int MaxKayitSuresi { get; set; }

        public bool AutoRenewOzelligi { get; set; }
    }

    public enum DomainPeriod
    {
        None,
        OnTalep,
        Sunrise,
        LandRush,
        GeneralAvailable
    }
}
