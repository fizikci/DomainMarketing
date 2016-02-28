using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.SSL
{
    public class ReqResolveCSR
    {
        [Description("CSR Code")]
        public string CSRCode { get; set; }

        public string CsrCodeClean { get; set; }
        public string PrivateKeyClean { get; set; }
        public string PrivateKey { get; set; }
        public short KeySize { get; set; }
    }
}
