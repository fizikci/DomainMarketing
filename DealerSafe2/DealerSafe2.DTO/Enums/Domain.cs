using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.Enums
{
    public enum ZoneGroups
    {
        None,
        Generic,
        Europe,
        Geographic,
        CcTld,
        NewGTld
    }

    public enum ZoneCategories
    {
        None,
        Community,
        Entertainment,
        Business,
        // etc...
    }

    public enum WhoIsServerTypes
    {
        Thick, // tüm qhois bilgisi
        Thin, //Domain info sadece
    }

    public enum PeriodTypes
    {
        Day,
        Month,
        Year,
    }

    public enum ContactTypes { 
        Admin,
        Billing,
        Owner
    }

    public enum DomainRenewalModes
    {
        Default = 0,
        RenewOnce = 1,
        AutoRenew = 2,
        AutoExpire = 3,
        AutoDelete = 4,
    }

    public enum DomainTransferModes
    {
        Default,
        AutoApprove,
        AutoDeny
    }


    public enum PrivacyProtectionOptions { Disabled = 0, Enabled = 1, NoInfo = 2, EnabledByWhoisHider = 3 }

    public enum OperationalStates
    {
        None,
        Suspend,
        Wipo,
        Malware
    }
    public enum TransferStates
    {
        None,
        ClientApproved,
        ClientCancelled,
        ClientRejected,
        Pending,
        ServerApproved,
        ServerCancelled
    }
}
