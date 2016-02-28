using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class ResCampingCustomerBackForward
    {
        public int RowNumber { get; set; }

        public int Id { get; set; }

        public string PhotoFile { get; set; }

        public string NameSurName { get; set; }

        public string ServiceContent { get; set; }

        public int Puan { get; set; }

        public bool PuanControl { get; set; }

        public DateTime Date { get; set; }

        public int MemberId { get; set; }
    }
}
