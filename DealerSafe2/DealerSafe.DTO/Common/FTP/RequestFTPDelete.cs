using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common.FTP
{
    public class RequestFTPDelete
    {
        public string Url { get; set; }
        public FileOrFolderTypes FileOrFolder { get; set; }
    }
    public enum FileOrFolderTypes
    {
        File, Folder
    }
}
