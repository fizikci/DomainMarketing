using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Enums
{
    public enum EnmRegisterResponse
    {
        Successfully = 0,
        AlreadyRegistered = 1,
        TimedOut = 2,
        Error = 3,
        DomainRegisteredOtherCompany = 4,
        ContactCreateError= 5,
    }
}
