using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqShareItem: BaseRequest
    {
        public string DMItemId { get; set; }
        public string ToEmail { get; set; }
        public string ToFullName { get; set; }
        public string Message { get; set; }
    }
}
