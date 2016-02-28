using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class CountryListInfo
    {
        public bool Process { get; set; }
        public List<CountryDetail> CountryList { get; set; }

        public class CountryDetail
        {
            public int Id { get; set; }
            public int UlkeKod { get; set; }
            public string UlkeAd { get; set; }
            public string UlkeAdKendiDili { get; set; }
            public string Alpha2UlkeKodu { get; set; }
            public string Alpha3UlkeKodu { get; set; }
            public int NumericUlkeKodu { get; set; }
            public string ISOUlkeKodu { get; set; }
            public string CcTLD { get; set; }
            public string CallingCode { get; set; }
            public string Currency { get; set; }
            public string CurrencySign { get; set; }
            public string CurrencyISOCode { get; set; }
            public int Status { get; set; }
            public bool Force3dSecurePayment { get; set; }
            public string Region { get; set; }
            public int UsingSMSCompanyID { get; set; }
        }
    }
}
