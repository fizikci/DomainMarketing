using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class ResCampingYearCustomer
    {
        public int Id { get; set; }

        public byte[] PhotoFile { get; set; }

        public string AplicationType { get; set; }

        public string Email { get; set; }

        public string SocialType { get; set; }

        public DateTime Date { get; set; }  
    
    }
}
