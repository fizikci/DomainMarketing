using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Orders;

namespace DealerSafe.DTO.Domain
{
    public class ResRemoveFromQueue
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
