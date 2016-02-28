using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class tblDirectionTo
    {
        public int Id { get; set; }
        public decimal DomainId { get; set; }
        public string DirectionType { get; set; }
        public string Url { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string RecordDate { get; set; }
        public int Status { get; set; }
        public int IsOtherCompany { get; set; }
    }
}
