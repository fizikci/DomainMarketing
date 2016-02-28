using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class GetBrandFilesInfo
    {
        public bool Process { get; set; }
        public List<BrandFileDetail> BrandFiles { get; set; }
    }
    public class BrandFileDetail
    {
        public int Id { get; set; }
        public int BrandID { get; set; }
        public int FileID { get; set; }
        public string FileDescription { get; set; }
        public string FileName { get; set; }
        public int FileStatus { get; set; }
        public int ProcessStatus { get; set; }
        public string RejectionMessage { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
