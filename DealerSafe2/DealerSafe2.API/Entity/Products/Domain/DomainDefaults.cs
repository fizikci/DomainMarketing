using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinar.Database;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Products.Domain
{
    public class DomainDefaultsForMember : DomainDefaults // one-to-one with Member
    {
    }
    public class DomainDefaultsForClient : DomainDefaults // one-to-one with Client
    {
    }
    public class DomainDefaultsForZone : DomainDefaults // one-to-one with Product
    {
    }
    public class DomainDefaultsForRegistry : DomainDefaults // one-to-one with Supplier
    {
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

        public DomainDefaults() 
        {
            // default contact id atamasını burada yapalım
            OwnerDomainContactId = "LLHKBR";
            AdminDomainContactId = "LLHKBR";
            TechDomainContactId = "LLHKBR";
            BillingDomainContactId = "LLHKBR";
        }
    }

}