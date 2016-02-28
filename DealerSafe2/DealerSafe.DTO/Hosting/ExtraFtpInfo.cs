using System;
using System.ComponentModel.DataAnnotations;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class ExtraFtpInfo
    {
        //[Required(ErrorMessage = "{0} alan� gereklidir")]
        [Display(Name = "Dosya Yolu")]
        public string FilePath { get; set; }

        [Required(ErrorMessage = "{0} alan� gereklidir")]
        [Display(Name = "FTP Kullan�c� Ad�")]
        [RegularExpression(@"(^([a-z]){1})+([A-Za-z0-9_\-\.]){5,15}$", ErrorMessage = "Minimum 6 karakterden olu�mal� ve harfle ba�lamal�d�r. �rn: test_ftp123")]
        public string FtpUserName { get; set; }

        [Required(ErrorMessage = "{0} alan� gereklidir")]
        [Display(Name = "FTP Kullan�c� �ifresi")]
        [StringLength(15, ErrorMessage = "�ireniz minimum 6 karakter olmal�", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$", ErrorMessage = "�ifrenizde b�y�k harf ve rakam da kullan�n�z. �rn: a1B2c3")]
        public string FtpPassword { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }

         [Display(Name = "Okuma izni")]
        public bool ReadPermission { get; set; }

         [Display(Name = "Yazma izni")]
        public bool WritePermission { get; set; }

        public bool PanelUser { get; set; }

        //ana sayfadan ftp �ifresini de�i�tirmede ayn� metoda gitmesi i�in parametre olarka eklendi
        public bool MainPage { get; set; }

        public string FtpServer { get; set; }

        public string DomainUser { get; set; }
    }
}