using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class GetCustomerBrandListInfo
    {
        public bool Process { get; set; }
        public List<BrandDetail> CustomerBrandlist { get; set; }
    }
    public class BrandDetail
    {
        public int Id { get; set; }
        public string BrandOwner { get; set; }
        public string BrandName { get; set; }
        public string ClassList { get; set; }
        public DateTime BrandRegistrationDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int OrderID { get; set; }
    }
}
