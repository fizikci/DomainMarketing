namespace DealerSafe2.DTO.Enums
{
    public enum MemberStates
    {
        WaitingEmailConfirmation,
        WaitingSMSConfirmation,
        ConfirmedWithFacebook,
        Confirmed,
        Suspended
    }

    public enum MemberTypes
    {
        Individual,
        Corporate,
        Reseller
    }

    public enum Departments
    {
        None,
        Domain,
        Hosting,
        SSL,
        Marka,
        Marketing,

    }

    public enum AddressTypes
    {
        DefaultAddress, 
        Shipping,
        Invoice
    }

    public enum ListInPartnerNetwork
    {
        None,
        Standart,
        Premium
    }

    public enum SupportGroup
    {
        None,
        Standart,
        Premium
    }
}
