using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Common
{
    public class ReqCampingYearCustomerList
    {
        public EnmCampaignCustomerYear2014Status Status { get; set; }

        public int RowStartIndex { get; set; }

        public int RowEndIndex { get; set; }  
    }
}
