using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark.DataTable
{
    public class MarkRequestInfo
    {
        public int recordsReturned { get; set; }
        public int totalRecords { get; set; }
        public int startIndex { get; set; }
        public string sort { get; set; }
        public string dir { get; set; }
        public int pageSize { get; set; }
        public string param { get; set; }
        public List<MarkRequsetDetail> records { get; set; }

        public class MarkRequsetDetail : DealerSafe.DTO.Mark.DataTable.Interface.IDataTable
        {
            public int RefID { get; set; }
            public int MemberID { get; set; }
            public int OrderID { get; set; }
            public string BrandOwner { get; set; }
            public string PhoneNumber { get; set; }
            public string MobileNumber { get; set; }
            public string BrandEmail { get; set; }
            public string BrandName { get; set; }
            public List<int> ClassList { get; set; }
            public string CustomerDesc { get; set; }
            public string Type_ { get; set; }
            public string RequestDate { get; set; }
        }
    }
}
