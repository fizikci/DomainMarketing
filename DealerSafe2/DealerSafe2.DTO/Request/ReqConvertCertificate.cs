namespace DealerSafe2.DTO.Request
{
    public class ReqConvertCertificate : BaseRequest
    {
        public ConvertType CertificateConvertType { get; set; }
        public string SourceFileName { get; set; }
        public string DestinationFileName { get; set; }
    }

    public enum ConvertType
    {
        PEMtoDER,
        PEMtoP7B,
        PEMtoPFX,
        DERtoPEM,
        P7BtoPEM,
        P7BtoPFX,
        PFXtoPEM
    }
}
