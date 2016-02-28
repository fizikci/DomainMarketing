using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Mark;

namespace DealerSafe.DTO.Enums
{
    public enum EnmHostingQueueResult
    {
        Waiting = 0,
        Successful = 1,
        TryAgain = 2,
        Failed = 3,
    }
}
