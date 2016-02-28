using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Hosting
{
    public class HostingTransactionInfo
    {
        public int Id { get; set; }
        public int MemberProductId { get; set; }
        public int OrderDetailId { get; set; }
        public int ProductTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public int Process { get; set; }
    }
}
