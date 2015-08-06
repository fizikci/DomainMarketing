using System;

namespace DealerSafe2.DTO.Enums
{
    public class StringAttr : Attribute { }

    public enum SSLStates
    {
        None,
        CSRReceived,
        SentToCA,
        DomainValidated,
        WaitingDocument,
        Completed,
        Failed
    }

    [Flags]
    public enum ComodoResponseType
    {
        ZipArchive = 0,
        NetscapeCertificateSequence = 1,
        PKCS7 = 2,
        IndividualyEncoded = 3
    }

    [Flags]
    public enum ComodoResponseEncoding
    {
        BASE64 = 0, Binary = 1
    }

    [StringAttr]
    public enum ComodoDcvMethod
    {
        EMAIL,
        HTTP_CSR_HASH,
        HTTPS_CSR_HASH,
        CNAME_CSR_HASH
    }

    [Flags]
    public enum ComodoServerSoftware
    {
        AOL = 1,
        ApacheModSSL = 2,
        ApacheSSLBenSSLNotStronghold = 3,
        C2NetStronghold = 4,
        Cisco3000SeriesVPNConcentrator = 33,
        Citrix = 34,
        CobaltRaq = 5,
        CovalentServerSoftware = 6,
        Ensim = 29,
        HSphere = 32,
        IBMHTTPServer8 = 7,
        iPlanet = 9,
        JavaWebServer = 10,
        LotusDomino = 11,
        LotusDominoGo = 12,
        MicrosoftIIS1XTo4X = 13,
        MicrosoftIIS5XTo6X = 14,
        MicrosoftIIS7XAndLater = 35,
        NetscapeEnterpriseServer = 15,
        NetscapeFastTrack = 16,
        nginx = 36,
        NovellWebServer = 17,
        Oracle = 18,
        Plesk = 30,
        QuidProQuo = 19,
        R3SSLServer = 20,
        RavenSSL = 21,
        RedHatLinux = 22,
        SAPWebApplicationServer = 23,
        Tomcat = 24,
        WebsiteProfessional = 25,
        WebStar4XAndLater = 26,
        WebTenFromTenon = 27,
        WHMcPanel = 31,
        ZeusWebServer = 28,
        Other = -1,
    }

    [Flags]
    public enum ComodoCsrStatus
    {
        NotRequired = -1, NotCompleted = 1, Completed = 1, InProgress = 2
    }

    [Flags]
    public enum ComodoDcvStatus
    {
        NotRequired = -1, NotCompleted = 1, Completed = 1, InProgress = 2
    }

    [Flags]
    public enum ComodoOvCallBackStatus
    {
        NotRequired = -1, NotCompleted = 1, Completed = 1, InProgress = 2
    }

    [Flags]
    public enum ComodoOrganizationValidationStatus
    {
        NotRequired = -1, NotCompleted = 1, Completed = 1, InProgress = 2
    }

    [Flags]
    public enum ComodoFreeDVUPStatus
    {
        NotRequired = -1, NotCompleted = 1, Completed = 1, InProgress = 2
    }

    [Flags]
    public enum ComodoEvClickThroughStatus
    {
        NotRequired = -1, NotCompleted = 1, Completed = 1, InProgress = 2
    }
}
