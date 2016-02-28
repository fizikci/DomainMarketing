using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class BlogRss
    {
        public int Id { get; set; }
        public string Konu { get; set; }
        public string Link { get; set; }
        public DateTime CTime { get; set; }
    }
}
