using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Enums
{
    public enum EppQueueStatuses
    {
        None,
        New,
        Processing,
        Done,
        Failed
    }

    public enum EppQueueCommands
    {
        ContactCheck,               // 0
        ContactCreate,
        ContactDelete,
        ContactInfo,
        ContactTransferApprove,
        ContactTransferCancel,
        ContactTransferQuery,
        ContactTransferReject,
        ContactTransferRequest,
        ContactUpdate,
        DomainCheck,                // 10
        DomainCreate,
        DomainDelete,
        DomainInfo,
        DomainRenew,
        DomainTransferApprove,
        DomainTransferCancel,
        DomainTransferQuery,
        DomainTransferReject,
        DomainTransferRequest,
        DomainUpdate,               // 20
        HostCheck,
        HostCreate,
        HostDelete,
        HostInfo,
        HostUpdate,
        Login,
        Logout,
        Hello,
        PollRequest,
        PollAcknowledge,            // 30
        DebugThrowException,
        DebugKillEppConnection,
        FinanceInfo,
        DebugDomainCheckAbuse
    }
}
