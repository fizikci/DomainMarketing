using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResDomainWhoisLookUpGet
    {
        public bool Available { get; set; }

        public bool IsIsimTescil { get; set; }

        public bool Durum { get; set; }

        public string DomainName { get; set; }

        public int TldId { get; set; }

        public string Registrar { get; set; }

        public string Iana_Id { get; set; }

        public string Registrar_Abuse_ContactPhone { get; set; }

        public string Registrar_Abuse_ContactEmail { get; set; }

        public Dictionary<string, string> NameServers { get; set; }

        public string Registrant_Name { get; set; }

        public string Registrant_Organization { get; set; }

        public string Registrant_Email { get; set; }

        public string Registrant_Phone { get; set; }

        public string Registrant_Adresess { get; set; }

        public string Registrant_City { get; set; }

        public string Registrant_Country { get; set; }

        public string Status { get; set; }

        public string Creation_Date { get; set; }

        public string Updated_Date { get; set; }

        public string Expiration_Date { get; set; }

        public string WhoisServer { get; set; }

        public int DomainEndDay { get; set; }

        public int DomainYearTime { get; set; }

        public bool TransferProtected { get; set; }

        public bool DeletedProtected { get; set; }

        public bool UpdateProtected { get; set; }

        public bool WhoisTransferControl { get; set; }

        public bool WhoisDeleteControl { get; set; }

        public bool WhoisUpdateControl { get; set; }

        public string WhoisDetailStr { get; set; }

        public int WhoisQueryCount { get; set; }
    }
}
