using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark.DataTable
{
    public class MarkOrdersInfo
    {
        public int recordsReturned { get; set; }
        public int totalRecords { get; set; }
        public int startIndex { get; set; }
        public string sort { get; set; }
        public string dir { get; set; }
        public int pageSize { get; set; }
        public List<MarkOrdersDetail> records { get; set; }

        public class MarkOrdersDetail : DealerSafe.DTO.Mark.DataTable.Interface.IDataTable
        {
            public int MarkID { get; set; }
            public int OrderID { get; set; }
            public int MemberID { get; set; }
            public string Username { get; set; }
            public string FullName { get; set; }
            public string MemberPhone { get; set; }
            public string EmailAddress { get; set; }
            public string MarkName { get; set; }
            public List<int> ClassList { get; set; }
            public string MemberDescription { get; set; }
            public string LastProcessDate { get; set; }
            public string OrderDate { get; set; }
            public double Price { get; set; }
            public int BrandStatus { get; set; }
            public int ProductId { get; set; }
            public int TPEStatus { get; set; }
        }
    }
}
