using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Epp.Request
{
    public class ReqBase
    {
        public UseCompanyOptions UseCompany { get; set; }
        public string DirectiRequestUrl;
        public string NicTrRequestUrl;
    }

    public enum UseCompanyOptions
    {
        Any,
        Directi,
        NicTR
    }
}
