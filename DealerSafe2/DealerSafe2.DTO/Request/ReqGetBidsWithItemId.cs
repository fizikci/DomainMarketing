﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqGetBidsWithItemId : ReqPager
    {
        public string DMItemId { get; set; }
    }
}
