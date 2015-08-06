using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class DMMemberInfo
    {
        public string FullName { get; set; }
        public string Country { get; set; }
        public string Avatar { get; set; }
        public string Website { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Medal { get; set; }
        public int Rating { get; set; }
    }
}
