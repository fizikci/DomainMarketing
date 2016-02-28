using System;
using System.ComponentModel.DataAnnotations;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class SubdomainInfo
    {
        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Subdomain Adý")]
        // [RegularExpression(@"^([A-Za-z]){1,20}$", ErrorMessage = "Sadece harf içerebilir. örn: test")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Sadece harf ve rakam içerebilir. örn: test örn: test1 örn: 1")]
        public string SubdomainName { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "FTP Kullanýcý Adý")]
        [StringLength(15, ErrorMessage = "Kullanýcý adý minimum 6 karakter olmalý", MinimumLength = 6)]
        [RegularExpression(@"^([a-z])+([A-Za-z0-9_\-\.]){5,15}$", ErrorMessage = "Minimum 6 karakterden oluþmalý ve harfle baþlamalýdýr. örn: test_ftp123")]
        public string FtpUserName { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "FTP Kullanýcý Þifre")]
        [StringLength(15, ErrorMessage = "Þireniz minimum 6 karakter olmalý", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$", ErrorMessage = "Þifrenizde büyük harf ve rakam da kullanýnýz. örn: a1B2c3")]
        public string FtpPassword { get; set; }

        public string SubdomainPath { get; set; }
        public int Id { get; set; }
        public string OperatingSystem { get; set; }
    }
}