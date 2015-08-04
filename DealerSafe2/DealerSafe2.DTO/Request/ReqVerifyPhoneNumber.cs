using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.Request
{
    public class ReqVerifyPhoneNumber : BaseRequest
    {
        public string Keyword { get; set; }
        public string PhoneNumber { get; set; }

    }
}
