using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqSaveBrandFile
    {
        public int BrandID { get; set; }
        public int FileID { get; set; }
        public string FileDescription { get; set; }
        public string FileName { get; set; }
        public int FileStatus { get; set; }
        public int ProcessStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
