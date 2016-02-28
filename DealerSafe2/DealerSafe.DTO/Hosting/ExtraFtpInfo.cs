using System;
using System.ComponentModel.DataAnnotations;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class ExtraFtpInfo
    {
        //[Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Dosya Yolu")]
        public string FilePath { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "FTP Kullanýcý Adý")]
        [RegularExpression(@"(^([a-z]){1})+([A-Za-z0-9_\-\.]){5,15}$", ErrorMessage = "Minimum 6 karakterden oluþmalý ve harfle baþlamalýdýr. örn: test_ftp123")]
        public string FtpUserName { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "FTP Kullanýcý Þifresi")]
        [StringLength(15, ErrorMessage = "Þireniz minimum 6 karakter olmalý", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$", ErrorMessage = "Þifrenizde büyük harf ve rakam da kullanýnýz. örn: a1B2c3")]
        public string FtpPassword { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }

         [Display(Name = "Okuma izni")]
        public bool ReadPermission { get; set; }

         [Display(Name = "Yazma izni")]
        public bool WritePermission { get; set; }

        public bool PanelUser { get; set; }

        //ana sayfadan ftp þifresini deðiþtirmede ayný metoda gitmesi için parametre olarka eklendi
        public bool MainPage { get; set; }

        public string FtpServer { get; set; }

        public string DomainUser { get; set; }
    }
}