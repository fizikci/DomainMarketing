using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class IP2CountryInfo
    {
        public bool Process { get; set; }
        public CountryDetailByIP CountryDetail { get; set; }
    }

    public class CountryDetailByIP
    {
        public string IPAddress { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimeZone { get; set; }
        public string IspName { get; set; }
        public string OrganizationName { get; set; }
        public string AsNumberOrName { get; set; }
    }

}
