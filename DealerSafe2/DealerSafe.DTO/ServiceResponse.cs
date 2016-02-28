using System.Collections.Generic;

namespace DealerSafe.DTO
{
    public class ServiceResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> ExtraMessages { get; set; }
        public T Data { get; set; }
        public string ClientIPAddress { get; set; }

        public long ServerProcessTime { get; set; }

        public int ErrorType { get; set; }
    }
}
