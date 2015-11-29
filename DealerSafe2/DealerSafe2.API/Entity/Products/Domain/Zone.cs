// bu öldü
/*
using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.Products.Domain
{
    public class Zone : NamedEntity
    {
        [ColumnDetail(Length=12)]
        public string RegistryId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public ZoneGroups ZoneGroup { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public ZoneCategories ZoneCategory { get; set; }

        [ColumnDetail(Length = 80)]
        public string WhoIsServer { get; set; }
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public WhoIsServerTypes WhoIsServerType { get; set; }

        public bool IdnCompatible { get; set; }
        public string IdnLanguages { get; set; }

        public bool BTmchSupport { get; set; }
        public bool BDpmiSupport { get; set; }
        public bool BAbuseContactPolicyEnabled { get; set; }


        public DateTime StagePreorderStart { get; set; }
        public DateTime StagePreorderEnd { get; set; }
        public DateTime StageSunriseStart { get; set; } // Bu dönemde TMCH IDsi ile talep yapılır, daha pahalıdır 
        public DateTime StageSunriseEnd { get; set; }
        public DateTime StageLandrushStart { get; set; } // İlk gelen özel fiyattan alır
        public DateTime StageLandrushEnd { get; set; }
        public DateTime StageEarlyAccessStart { get; set; }
        public DateTime StageEarlyAccessEnd { get; set; }
        public DateTime StageGeneralAvailableStart { get; set; } // normal domain satışının başladığı tarih

        public string AttrNameRegEx { get; set; }
        public bool AttrROID { get; set; }
        public bool AttrEppStatus { get; set; }
        public bool AttrRGPStatus { get; set; }
        public bool AttrRegistrant { get; set; }
        public bool AttrContact { get; set; }
        public bool AttrNameServer { get; set; }
        public bool AttrHost { get; set; }
        public bool AttrSponsorId { get; set; }
        public bool AttrCreatorId { get; set; }
        public bool AttrUpdateDate { get; set; }
        public bool AttrExpiryDate { get; set; }
        public bool AttrTransferDate { get; set; }
        public bool AttrLastUpdatingAccountId { get; set; }
        public bool AttrAuthInfo { get; set; }
        public bool AttrAuthInfoRegEx { get; set; }
        public bool AttrAuthCodeCharRange { get; set; }
        public bool AttrLanguageTag { get; set; }
        public bool AttrUserForm { get; set; }
        public bool AttrVariant { get; set; }
        public bool AttrKeyData { get; set; }
        public bool AttrDsData { get; set; }
        public bool AttrKeyValue { get; set; }
        public bool AttrWhoisProtection { get; set; }
        public bool AttrClientTransferLock { get; set; }
        public bool AttrServerTransferLock { get; set; }
        public bool AttrNameServerUpdate { get; set; }
        public bool AttrContactUpdate { get; set; }
        public bool AttrDeleteDomain { get; set; }
        public bool AttrDnsSecEnabled { get; set; }
        public bool AttrExpiryDateSetEnabled { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public PeriodTypes LCRegistrationPeriodType { get; set; }
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public PeriodTypes LCLifeCyclePeriodType { get; set; }
        public int LCRegistrationPeriod { get; set; }
        public int LCExpiredPeriod { get; set; }
        public int LCAutoRenewGracePeriod { get; set; }
        public int LCRedemptionPeriod { get; set; }
        public int LCPendingDeletePeriod { get; set; }
        public int LCRenewalmode { get; set; }
        public int LCMoneyBackGracePeriod { get; set; }
        public int LCRegistrationTransferLockPeriod { get; set; }
        public int LCWhoisUpdateTransferLockPeriod { get; set; }

        public int FeeApplication { get; set; }
        public int FeeSunrise { get; set; }
        public int FeeLandrush { get; set; }
        public int FeeEarlyAccess { get; set; }
        public int FeeGeneralRegistration { get; set; }
        public int FeeRenewalPrice { get; set; }
        public int FeeTransferPrice { get; set; }
        public int FeeRestorePrice { get; set; }
        public int FeeIcannFee { get; set; }
        public int FeeCommision1 { get; set; }
        public int FeeCommision2 { get; set; }
        public int FeeCommision3 { get; set; }
        public string FeeCurrency { get; set; }
    }
}
*/