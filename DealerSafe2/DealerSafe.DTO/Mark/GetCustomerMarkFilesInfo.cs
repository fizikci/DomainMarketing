using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class GetCustomerMarkFilesInfo
    {
        public List<CustomerMarkFileDetail> CustomerMarkFiles { get; set; }
    }
    public class CustomerMarkFileDetail
    {
        public int MarkID { get; set; }
        public string BrandName { get; set; }
        public string BrandStatus { get; set; }
        public string TPEStatus { get; set; }
        public int BrandStatusId { get; set; }
        public int TPEStatusId { get; set; }
        public string CustomerNotes { get; set; }
        public string ClassList { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
