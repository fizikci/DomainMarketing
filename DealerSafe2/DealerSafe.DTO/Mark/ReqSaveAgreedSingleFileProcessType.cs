using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqSaveAgreedSingleFileProcessType
    {
        public int FileId { get; set; }
        public int MarkId { get; set; }
        public string AgreedSingleFileProcessType { get; set; }
        public string RejectionCause { get; set; }
    }
}
