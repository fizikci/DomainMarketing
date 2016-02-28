using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class DomainNewsInfo
    {
        public int Id { get; set; }
        public bool Status { get; set; } // true : aktif haberler
        public DateTime InsertDate { get; set; }
        public string Title { get; set; }
        public string Spot { get; set; }
        public string NewsContent { get; set; }
        public string Image { get; set; }
    }
}
