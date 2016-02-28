using System;
using System.ComponentModel.DataAnnotations;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class DnsInfo
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Dosya Yolu")]
        public string Type { get; set; }

        [Display(Name = "Kayýt")]
        [Required(ErrorMessage = "*")]
        public string Record { get; set; }

        [Display(Name = "Deðer")]
        [Required(ErrorMessage = "*")]
        public string Value { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "IP Adresi")]
        public string IpAddress { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Name Server")]
        public string NameServer { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Öncelik")]
        public string Priority { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Host")]
        public string Host { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Yönlendirme Adresi")]
        public string RouteAddress { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Web Server Ip")]
        public string WebServerIp { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Ftp Server Ip")]
        public string FtpServerIp { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Mail Server Ip")]
        public string MailServerIp { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Mail Adresiniz")]
        public string MailAddress { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "GMAIL CNAME Bilgisi")]
        public string GmailCnameInfo { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "GMAIL MX Bilgisi")]
        public string GmailMXInfo { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Domain")]
        public string Domain { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Google CNAME")]
        public string GoogleCname { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "HOTMAÝL TXT Bilgisi")]
        public string HotmailTxtInfo { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "HOTMAÝL MX Bilgisi")]
        public string HotmailMxInfo { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Google Dogrulama Kodu")]
        public string GoogleCode { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Google Cname Adý")]
        public string GoogleUserCname { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Yandex Cname Kayýt Adý")]
        public string YandexCname { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Yandex Cname Kayýt Bilgisi")]
        public string YandexCnameInfo { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Yandex MX Bilgisi")]
        public string YandexMxInfo { get; set; }
        


        public EnmDnsTypes DnsType
        {
            get
            {
                switch (Type)
                {
                    case "A": return EnmDnsTypes.A;
                    case "NS": return EnmDnsTypes.NS;
                    case "CNAME": return EnmDnsTypes.CNAME;
                    case "MX": return EnmDnsTypes.MX;
                    case "TXT": return EnmDnsTypes.TXT;
                    case "SPF": return EnmDnsTypes.SPF;
                    case "GMAIL_SERVICE": return EnmDnsTypes.GMAÝL_SERVÝS;
                    case "KENDI_IP": return EnmDnsTypes.KENDÝ_SABÝT_ÝP;
                    case "GMAIL_WEB": return EnmDnsTypes.GMAÝL_WEB_ALAN;
                    case "HOTMAIL": return EnmDnsTypes.HOTMAÝL;
                    case "YANDEX_SERVICE": return EnmDnsTypes.YANDEX_SERVICE;
                }
                return EnmDnsTypes.TANIMSIZ;
            }
        }

        public int Id { get; set; }
        public string Temp { get; set; }
    }
}