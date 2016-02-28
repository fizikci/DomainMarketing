using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqTldGeneralUpdate
    {

        public string TldId { get; set; }

        public string TldName { get; set; }

        public string Status { get; set; }

        public int DnsType { get; set; }

        public int SiraIndex { get; set; }

        public int IsSummaryDomain { get; set; }

        public int IsNewGtld { get; set; }

        public int IsIDN { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int TldPopularitePercent { get; set; }

        public string Description1 { get; set; }

        public string InvestmentValue { get; set; }

        public int QueryCompanyID { get; set; }

        public int AlternativeCompanyID { get; set; }

        public int BuyingCompanyID { get; set; }

        public int TransferCompanyID { get; set; }

        public int ContactCompatibility { get; set; }

        public int ContactType { get; set; }

        public int AutoRegister { get; set; }

        public int RenewalMode { get; set; }

        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public int HideDurationStart { get; set; }

        public int HideDurationFinish { get; set; }

    }
}
