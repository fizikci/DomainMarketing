using System;
using System.ComponentModel.DataAnnotations;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class SubdomainInfo
    {
        [Required(ErrorMessage = "{0} alan� gereklidir")]
        [Display(Name = "Subdomain Ad�")]
        // [RegularExpression(@"^([A-Za-z]){1,20}$", ErrorMessage = "Sadece harf i�erebilir. �rn: test")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Sadece harf ve rakam i�erebilir. �rn: test �rn: test1 �rn: 1")]
        public string SubdomainName { get; set; }

        [Required(ErrorMessage = "{0} alan� gereklidir")]
        [Display(Name = "FTP Kullan�c� Ad�")]
        [StringLength(15, ErrorMessage = "Kullan�c� ad� minimum 6 karakter olmal�", MinimumLength = 6)]
        [RegularExpression(@"^([a-z])+([A-Za-z0-9_\-\.]){5,15}$", ErrorMessage = "Minimum 6 karakterden olu�mal� ve harfle ba�lamal�d�r. �rn: test_ftp123")]
        public string FtpUserName { get; set; }

        [Required(ErrorMessage = "{0} alan� gereklidir")]
        [Display(Name = "FTP Kullan�c� �ifre")]
        [StringLength(15, ErrorMessage = "�ireniz minimum 6 karakter olmal�", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$", ErrorMessage = "�ifrenizde b�y�k harf ve rakam da kullan�n�z. �rn: a1B2c3")]
        public string FtpPassword { get; set; }

        public string SubdomainPath { get; set; }
        public int Id { get; set; }
        public string OperatingSystem { get; set; }
    }
}