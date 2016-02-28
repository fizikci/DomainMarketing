using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class MembersDnsTo
    {
        public int Id { get; set; }
        public decimal OrderID { get; set; }
        public decimal MemberID { get; set; }
        public decimal ProductID { get; set; }
        public string DomainName { get; set; }
        public int DomainPeriod { get; set; }
        public string DNS1 { get; set; }
        public string DNS2 { get; set; }
        public int Activity { get; set; }
        public int Status { get; set; }
        public string RegisterCompany { get; set; }
        public decimal DirectiOrderID { get; set; }
        public decimal DirectiCustomerID { get; set; }
        public string Secret { get; set; }
        public string DomainStatus { get; set; }
        public int DomainProcess { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int PrivacyProtection { get; set; }
        public int DomainSituation { get; set; }
        public string NicTrTicketNumber { get; set; }
        public int ApplicationType { get; set; }
        public decimal GroupID { get; set; }
        public decimal ContactIDRegistry { get; set; }
        public string NicTrDNSTciketNumber { get; set; }
        public string DNS3 { get; set; }
        public string DNS4 { get; set; }
        public int SendDocCount { get; set; }
        public int NicTrIslemTipiSonuc { get; set; }
        public int DNSID { get; set; }
        public int SelectedDNS { get; set; }
        public decimal ContactIDAdmin { get; set; }
        public decimal ContactIDTech { get; set; }
        public decimal ContactIDBilling { get; set; }
        public decimal UzantiID { get; set; }
        public string TransferStartDate { get; set; }
        public int RefContId { get; set; }
        public int VeriSignDeleted { get; set; }
        public int AutoRegisterResult { get; set; }
    }
}
