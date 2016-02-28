namespace DealerSafe.DTO
{
    public class ServiceRequest<T>
    {
        public string APIKey { get; set; }
        public int ResellerId { get; set; }
        public int MemberId { get; set; }
        public int StaffId { get; set; }
        public T Data { get; set; }

        public string ClientIP { get; set; }
        public string Browser { get; set; }
        public string UserAgent { get; set; }
        public string Client { get; set; }
        public string SessionId { get; set; }
    }
}
