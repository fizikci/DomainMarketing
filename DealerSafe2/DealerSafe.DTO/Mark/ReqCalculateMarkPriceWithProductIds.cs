using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqCalculateMarkPriceWithProductIds
    {
        public List<int> ProductIdList { get; set; }
    }
}
