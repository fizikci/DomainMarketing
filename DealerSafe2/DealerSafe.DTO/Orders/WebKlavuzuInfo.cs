using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class WebKlavuzuInfo
    {
        public bool Process { get; set; }
        public List<WebKlavuzuDetail> WebKlavuzuList { get; set; }

        public class WebKlavuzuDetail
        {
            public int Id { get; set; }
            public int ProductTypeID { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
            public double Tax { get; set; }
        }
    }
}
