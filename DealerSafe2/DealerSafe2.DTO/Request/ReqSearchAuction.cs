using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqSearchAuction : BaseRequest
    {
        public string StartsWith { get; set; }
        public string EndsWith { get; set; }
        public string Including { get; set; }
        public string Extention { get; set; }
        public string CategoryId { get; set; }
        public DMItemTypes Type { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
