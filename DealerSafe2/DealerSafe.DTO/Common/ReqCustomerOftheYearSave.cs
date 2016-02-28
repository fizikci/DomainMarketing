using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Common
{
    public class ReqCustomerOftheYearSave
    {
        public string ServicesType { get; set; }

        public string ServiceContent { get; set; }

        public byte[] PhotoFile { get; set; }

        public string Email { get; set; }

        public string SocialType { get; set; }

        public int MemberId { get; set; }

        public string Ipadress { get; set; }

        public string Cookie { get; set; }

        public EnmCampaignCustomerYear2014Status Type { get; set; }

        public string SocialToken { get; set; }

        public string SocialSecret { get; set; }
    }
}
