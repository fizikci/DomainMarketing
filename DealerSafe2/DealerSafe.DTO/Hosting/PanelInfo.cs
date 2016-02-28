using System;
using System.ComponentModel.DataAnnotations;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class PanelInfo
    {
        [Display(Name = "Panel Adresiniz")]
        public string PanelAddress { get; set; }

        [Display(Name = "Panel Kullanýcý Adýnýz")]
        public string PanelUserName { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Panel Þifreniz")]
        public string PanelPassword { get; set; }

        public string ClientId { get; set; }
    }
}