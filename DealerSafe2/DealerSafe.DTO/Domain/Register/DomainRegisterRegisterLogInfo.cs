using System;

namespace DealerSafe.DTO.Domain.Register
{
    public class DomainRegisterRegisterLogInfo
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public string DomainName { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public int RegisterType { get; set; }
        public int ReferenceId { get; set; }
        public int RegisterRequestId { get; set; }
    }
}
