namespace DealerSafe.DTO.Domain.Register
{
    public class ResDomainRegisterRequest
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public int RequestId { get; set; }
        public int ReferenceId { get; set; }
    }
}
