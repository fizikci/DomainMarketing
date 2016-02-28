using System;
using System.ComponentModel.DataAnnotations;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class PanelInfo
    {
        [Display(Name = "Panel Adresiniz")]
        public string PanelAddress { get; set; }

        [Display(Name = "Panel Kullan�c� Ad�n�z")]
        public string PanelUserName { get; set; }

        [Required(ErrorMessage = "{0} alan� gereklidir")]
        [Display(Name = "Panel �ifreniz")]
        public string PanelPassword { get; set; }

        public string ClientId { get; set; }
    }
}