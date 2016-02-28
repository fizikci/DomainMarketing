using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class OrgMousePadTo
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int MemberDnsId { get; set; }
        public DateTime Creation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsSend { get; set; }
        public DateTime CargoDate { get; set; }
        public string CargoTrackId { get; set; }
        //beklemede, gonderildi, geri döndü, iptal, 
        public string Status { get; set; }

        //daha musteriye sormamisiz
        public bool IsMemberAnswered { get; set; }

        //musteri kabul etmis mi
        public bool IsMemberApproved { get; set; }
    }
}
