using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class DomainUsersTo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RecDate { get; set; }
        public decimal RefferenceMember { get; set; }
    }
}
