using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqTldRequestInformation
    {
        public int MemberId { get; set; }
        public DateTime BasvuruTarihi { get; set; }
        public string Domain { get; set; }
        public int Aktif { get; set; }
    }
}
