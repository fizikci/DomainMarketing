using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.Register
{
    public class ResUpdateDomainNameServerRequest
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public int ReferenceId { get; set; }
    }
}
