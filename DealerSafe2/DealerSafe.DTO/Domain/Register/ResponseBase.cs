using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;
using DealerSafe.DTO.Epp.Response;

namespace DealerSafe.DTO.Domain.Register
{
    public class ResponseBase
    {
        public ResDomainCreate ResDomainCreate { get; set; }
        public bool Success { get; set; }
        public EnmRegisterResponse RegisterResponse { get; set; }
    }
}
