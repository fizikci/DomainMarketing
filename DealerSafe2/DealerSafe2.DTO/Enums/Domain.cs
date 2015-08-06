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

    public enum RegistryStates
    {
        /// <summary>
        /// Requests to delete the object MUST be rejected
        /// </summary>
        ClientDeleteProhibited,

        /// <summary>
        /// DNS delegation information MUST NOT be published for the object
        /// </summary>
        ClientHold,

        /// <summary>
        /// Requests to renew the object MUST be rejected
        /// </summary>
        ClientRenewProhibited,

        /// <summary>
        /// Requests to transfer the object MUST be rejected
        /// </summary>
        ClientTransferProhibited,

        /// <summary>
        /// Requests to update the object (other than to remove this status) MUST be rejected
        /// </summary>
        ClientUpdateProhibited,

        /// <summary>
        /// Delegation information has not been associated with the object
        /// </summary>
        Inactive,

        /// <summary>
        /// This is the normal status value for an object that has no pending operations or prohibitions
        /// </summary>
        Ok,

        /// <summary>
        /// Create command has been processed for the object, but the action has not been completed by the server
        /// </summary>
        PendingCreate,

        /// <summary>
        /// Delete command has been processed for the object, but the action has not been completed by the server
        /// </summary>
        PendingDelete,

        /// <summary>
        /// Renew command has been processed for the object, but the action has not been completed by the server
        /// </summary>
        PendingRenew,

        /// <summary>
        /// Transfer command has been processed for the object, but the action has not been completed by the server
        /// </summary>
        PendingTransfer,

        /// <summary>
        /// Update command has been processed for the object, but the action has not been completed by the server
        /// </summary>
        PendingUpdate,

        /// <summary>
        /// Requests to delete the object MUST be rejected
        /// </summary>
        ServerDeleteProhibited,

        /// <summary>
        /// DNS delegation information MUST NOT be published for the object
        /// </summary>
        ServerHold,

        /// <summary>
        /// Requests to renew the object MUST be rejected
        /// </summary>
        ServerRenewProhibited,

        /// <summary>
        /// Requests to transfer the object MUST be rejected
        /// </summary>
        ServerTransferProhibited,

        /// <summary>
        /// Requests to update the object (other than to remove this status) MUST be rejected
        /// </summary>
        ServerUpdateProhibited,

        /// <summary>
        /// Status MAY be combined with any status
        /// </summary>
        Linked
    }

    public enum RGPStates
    {

        /// <remarks/>
        addPeriod,

        /// <remarks/>
        autoRenewPeriod,

        /// <remarks/>
        renewPeriod,

        /// <remarks/>
        transferPeriod,

        /// <remarks/>
        pendingDelete,

        /// <remarks/>
        pendingRestore,

        /// <remarks/>
        redemptionPeriod,

        NONE
    }

    public enum PrivacyProtectionOptions { Disabled = 0, Enabled = 1, NoInfo = 2, EnabledByWhoisHider = 3 }

    public enum OperationalStates
    {
        None,
        Suspend,
        Wipo,
        Malware
    }
}
