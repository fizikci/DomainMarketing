using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark.DataTable.Request
{
    public class MarkRequest
    {
        public string Sort { get; set; }
        public string Dir { get; set; }
        public int StartIndex { get; set; }
        public int Results { get; set; }
        public string param { get; set; }

        public string Keyword { get; set; }
        public int SearchType { get; set; }
        public int Durumu { get; set; }
        public string RequestDate { get; set; }
    }
}
