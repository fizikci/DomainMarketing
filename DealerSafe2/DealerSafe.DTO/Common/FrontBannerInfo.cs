using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    /// <summary>
    /// Isimtescil.net'de goruntulenen bannerlar
    /// </summary>
    public class FrontBannerInfo
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsPopup { get; set; }
        public bool IsActive { get; set; }
        public BannerType Type { get; set; }

        //Her goruntulen resimde 1 artar ve density'si az olan 
        //resimlerin gosterilmesine oncelik verilir
        public int Density { get; set; }
    }

    public enum BannerType
    {
        None = 0,
        Basket = 1,
        MainRight = 2,
        MainBottom = 3
    };
}
