using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ResFrontBannerImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Url { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
