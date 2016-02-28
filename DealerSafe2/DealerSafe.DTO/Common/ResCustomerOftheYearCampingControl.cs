using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Common
{
    public class ResCustomerOftheYearCampingControl
    {



        public bool CampingStatus { get; set; }

        public EnmCampaignCustomerYear2014Status Status { get; set; }

        public byte[] PhotoFile { get; set; }

        public string Description { get; set; }

        public int Like { get; set; }

        public string NameSurName { get; set; }

        public DateTime Date { get; set; }

        public bool Vote { get; set; }

        public int CustomerId { get; set; }

        public int Sira { get; set; }
    }
}
