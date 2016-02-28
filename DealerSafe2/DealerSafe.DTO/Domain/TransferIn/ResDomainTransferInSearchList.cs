using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.TransferIn
{
    class ResDomainTransferInSearchList
    {
         
    }
    public class SearchList
    {
        public string Domain { get; set; }
        public string IdnName { get; set; }
        public string Company { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
        public int SearchStatus { get; set; }
        public int Auth { get; set; }
        public bool IsIdn { get { return IdnName == "xn--"; } }
    }
}
