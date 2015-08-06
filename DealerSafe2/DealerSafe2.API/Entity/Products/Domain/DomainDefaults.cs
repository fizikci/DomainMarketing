using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.Products.Domain
{
    public class DomainDefaultsForMember : DomainDefaults
    {
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
    }
    public class DomainDefaultsForClient : DomainDefaults
    {
        [ColumnDetail(Length = 12)]
        public string ClientId { get; set; }
    }
    public class DomainDefaultsForZone : DomainDefaults
    {
        [ColumnDetail(Length = 12)]
        public string ZoneId { get; set; }
    }
    public class DomainDefaultsForRegistry : DomainDefaults
    {
        [ColumnDetail(Length = 12)]
        public string RegistryId { get; set; }
    }
    public class DomainDefaults : NamedEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public DomainRenewalModes RenewalMode { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public DomainTransferModes TransferMode { get; set; }

        [ColumnDetail(Length = 12)]
        public string OwnerDomainContactId { get; set; } // whois veritabanındaki ID aynen kullanılabilir
        [ColumnDetail(Length = 12)]
        public string AdminDomainContactId { get; set; }
        [ColumnDetail(Length = 12)]
        public string TechDomainContactId { get; set; }
        [ColumnDetail(Length = 12)]
        public string BillingDomainContactId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public PrivacyProtectionOptions PrivacyProtection { get; set; }

        [ColumnDetail(Length = 400)]
        public string NameServers { get; set; }
    }

}