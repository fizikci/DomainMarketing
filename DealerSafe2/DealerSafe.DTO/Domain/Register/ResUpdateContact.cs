using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.Register
{
    public class ResUpdateContact
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }

        public int ContactInfoId { get; set; }
        public int ReferenceId { get; set; }
    }
}
