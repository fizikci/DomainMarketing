﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqNewTldUpdate
    {
        public string TldOldName { get; set; }

        public string TldName { get; set; }

        public int TldCompanyId { get; set; }

        public string DomainClass { get; set; }

        public int CharacterMin { get; set; }

        public int CharacterMax { get; set; }

        public bool IDNSupport { get; set; }

        public bool WhoisProtection { get; set; }

        public int BuyingMinYear { get; set; }

        public int BuyingMaxYear { get; set; }

        public bool OnTalep { get; set; }

        public decimal OnTalepBuying { get; set; }

        public float OnTalepSelling { get; set; }

        public bool SunRise { get; set; }

        public decimal SunRiseBuying { get; set; }

        public float SunRiseSelling { get; set; }

        public DateTime SunRiseStartDate { get; set; }

        public DateTime SunRiseEndDate { get; set; }

        public bool LandRush { get; set; }

        public decimal LandRushBuying { get; set; }

        public float  LandRushSelling { get; set; }

        public DateTime LandRushStartDate { get; set; }

        public DateTime LandRushEndDate { get; set; }

        public DateTime GeneralAvalibleStartDate { get; set; }

        public bool SpecialConditions { get; set; }

    }
}
