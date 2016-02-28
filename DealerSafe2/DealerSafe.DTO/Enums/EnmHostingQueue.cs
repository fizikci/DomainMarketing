using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Enums
{
    public enum EnmHostingQueue
    {
        ControlHosting,
        CreateHosting,
        CreateDomain,
        MoveHosting,
        DefaultHosting,
        RenewHosting,
        SuspendHosting,
        OperationChange,
        UpgradeHosting,
    }
}
