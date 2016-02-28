namespace DealerSafe.DTO.Hosting
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [Serializable]
    public class EmailInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "E-Posta Hesabý")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "E-Posta Þifresi")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15}$", ErrorMessage = "Þifrenizde büyük harf,küçük harf ve rakam kullanýnýz. örn: a1B2c3d4 (En az 8 karakter)")]
        public string Password { get; set; }

        [Display(Name = "Açýklama (Ad Soyad)")]
        public string Description { get; set; }

        public string EmailName { get; set; }

        public string ReadEmailLink { get; set; }

        [StringLength(4, ErrorMessage = "En fazla 4 karakter girebilirsiniz")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Sadece rakam kullanabilirsiniz")]
        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Mail Box Boyutu")]
        public string Limit { get; set; }

        public long UsedMailBoxSize { get; set; }
        public string DomainName { get; set; }

        public MailServiceSettings MailServiceSettings { get; set; }
    }
}
