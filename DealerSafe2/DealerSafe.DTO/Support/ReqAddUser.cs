using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Support
{
    public class ReqAddUser
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
