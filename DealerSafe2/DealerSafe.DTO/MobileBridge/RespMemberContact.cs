using System;

namespace DealerSafe.DTO.MobileBridge
{
    public class RespMemberContact
    {
        public int Id { get; set; }
        //public string ContactAlias { get; set; } 
        public bool RecStatus { get; set; }
        public DateTime RecCreationDate { get; set; }
        public int MemberId { get; set; }
        public bool Isdefault { get; set; }
        public int ContactCompatibility { get; set; } // jenerik, tr, co ...
        public int ContactType { get; set; } // bireysel, kurumsal
        //public string NameSurname { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; } // tr domainler ve bireysel ise doldurulmalı
        public string Company { get; set; } // kurumsal kontaklarda doldurulmalı
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string TaxOffice { get; set; } // tr domainler ve kurumsal ise zorunlu
        public string TaxNumber { get; set; } // tr domainler ve kurumsal ise zorunlu
        public int DomainUserId { get; set; }
        public int? IsApproved { get; set; } // kontakt onaylı / onaysız
    }
}
