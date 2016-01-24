using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqDMScreenshot
    {
        public string DMItemId { get; set; }
        public Base64Image[] ScreenShots { get; set; }
    }

    public class Base64Image
    {
        public int filesize { get; set; }
        public string filetype { get; set; }
        public string base64 { get; set; }
        public string filename { get; set; }
    }
}
