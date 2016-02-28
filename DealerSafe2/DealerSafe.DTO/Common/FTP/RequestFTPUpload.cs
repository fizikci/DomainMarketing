using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common.FTP
{
    public class RequestFTPUpload
    {
        public string FolderUrl { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public int FileLength { get; set; }
    }
}
