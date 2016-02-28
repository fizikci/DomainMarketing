using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class GetWaitingforFilesInfo
    {
        public List<WaitingForFileDetail> WaitingForFiles { get; set; }
    }
    public class WaitingForFileDetail
    {
        public int FileRefID { get; set; }
        public int BrandID { get; set; }
        public int FileID { get; set; }
        public string DescProcess { get; set; }
        public string FileDescription { get; set; }
        public string BrandName { get; set; }
    }
}
