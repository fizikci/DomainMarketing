namespace DealerSafe2.DTO.Response
{
    public class ResCollectSSL
    {
        public string notBefore { get; set; }
        public string notAfter { get; set; }
        public string fqdn { get; set; }
        public string zipFile { get; set; }
        public string netscapeCertificateSequence { get; set; }
        public string pkcs7 { get; set; }
        public string caCertificate { get; set; }
        public string certificate { get; set; }
        public string certificateStatus { get; set; }
        public string validationStatus { get; set; }

        public string csrStatus { get; set; }
        public string dcvStatus { get; set; }
        public string ovCallBackStatus { get; set; }
        public string organizationValidationStatus { get; set; }
        public string freeDVUPStatus { get; set; }
        public string evClickThroughStatus { get; set; }
    }
}
