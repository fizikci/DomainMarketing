using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqTldFavoriteAdd
    {
        public int MemberId { get; set; }
        public string TldName { get; set; }
    }
}
