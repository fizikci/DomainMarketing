using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Support
{
    public class ReqAddStaff
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string StaffGroupId { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
