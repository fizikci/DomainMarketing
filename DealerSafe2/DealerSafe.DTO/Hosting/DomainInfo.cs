using System;
using System.ComponentModel.DataAnnotations;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class DomainInfo
    {
        public int ID { get; set; }
        public int HostingId { get; set; }


        //[RegularExpression(@"^([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,50})$",
        //    ErrorMessage = "Lütfen domain ismini giriniz. örn :isimtescil.net")]
        [RegularExpression(@"^([a-z0-9_\-\.])+\.([a-z]{2,50})$",
          ErrorMessage = @"Lütfen domain ismini girin. örn :isimtescil.net")]
        [Required(ErrorMessage = "Bu alan gereklidir")]
        public string DomainName { get; set; }


        [Required(ErrorMessage = "Bu alan gereklidir")]
        [StringLength(10, ErrorMessage = "Minimum 4 maksimum 10 karakter olmalýdýr!", MinimumLength = 4)]
        public string DomainUser { get; set; }

        public DateTime CreatedDate { get; set; }
        public int? MembersDNSID { get; set; }
        //public string Password { get; set; }
        public string SubDomain { get; set; }

        public string Status { get; set; }

        public bool IsMailHost {get; set; }
    }
}