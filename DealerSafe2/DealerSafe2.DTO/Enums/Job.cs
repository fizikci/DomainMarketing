namespace DealerSafe2.DTO.Enums
{
    public enum JobCommands
    {
        None,

        // Orders related
        CancelRefundReq,

        // Resellers related
        CalculateResellerRefundAmounts,
        MdfApplication,

        // Domain related
        DomainRegister,
        DomainRenewal,
        DomainTransfer,
        DomainRestore,
        DomainDelete,

        // Hosting related
        HostingCreate,
        HostingSuspend,

        // SSL related
        SSLNewOrder,
        SSLGenerate,
        SSLCheckResult,
        SSLUpdateDCV,

        // Comodo hacker guardian related
        SiteProtectionNewOrder,

        // Crm
        NewTicket,
        NewFeedback,

        // Communication
        CCSendMessage,
    }

    public enum JobStates
    {
        NotStarted,
        Processing,
        TryAgain,
        Done,
        Failed,
        Canceled
    }

    public enum JobExecuters
    {
        Member,
        Staff,
        Machine
    }
}
