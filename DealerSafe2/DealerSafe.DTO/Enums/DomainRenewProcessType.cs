namespace DealerSafe.DTO.Enums
{
    public enum DomainRenewStatus
    {
        Incorrect = -1,
        Active = 1,
        Passive = 0,
        RequiredRestoration = 2,
        ProcessTimedOut = 3,
        SessionError = 4
    }

    public enum DomainRenewSuccess
    {
        Succeded = 1,
        WaitingProcess = 0,
        GeriAlmaBekleniyor = 2
    }

    public enum DomainRenewProcessType
    {
        DomainRenewRequestSave,
        GetDomainDatesFromRegistry,
        GetDomainDatesFromOur,
        GetDomainInfo,
        AutoRenewSuccess,
        AutoRenewFail,
        SendToDomainQueue,
        MembersDnsUpdate,
        RemoveDomainQueue,
        UpdateDomainQueue,
        UpdateIsSuccess,
        UpdateStatus,
        DomainRenewCheckError,
        DomainRenewCheckSuccess,
        UpdateDomainRenewCheck,
        DomainRenewRequestNotFound,
        DomainNotFound,
    }
}
