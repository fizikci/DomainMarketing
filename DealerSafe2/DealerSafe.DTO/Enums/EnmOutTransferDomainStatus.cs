using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Enums
{
    public enum EnmOutTransferDomainStatus
    {
        /////////////////////
        Empty = 0,
        Ok = 1,
        GunlukSurec60 = 2,
        ServerHold = 3,
        ClientHold = 4,
        RedemptionPeriod = 5,
        PendingDelete = 6,
        ClientTransferProhibited = 7,
        ClientDeleteProhibited = 8,
        ServerDeleteProhibited = 9,
        ServerTransferProhibited = 10,


        Inactive = 11,
        Suspended = 12,
        Deleted = 13,
        RenewHold = 14,
        /////////////////////

        ServerRenewProhibited = 15,
        PendingTransfer = 16,
        PendingUpdate = 17,
        PendingRenew = 18,
        PendingCreate = 19,
        ServerUpdateProhibited = 20,
        AddPeriod = 21,
        AutoRenewPeriod = 22,
        RenewPeriod = 23,
        TransferPeriod = 24,
        PendingRestore = 25,
        ClientRenewProhibited = 26,
        ClientUpdateProhibited = 27,
        ContactEmailFound = 28



    }
}
