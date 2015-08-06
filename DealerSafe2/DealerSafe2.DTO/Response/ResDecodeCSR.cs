using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.Response
{
    public class ResDecodeCSR
    {
        public string CN { get; set; }
        public string OU { get; set; }
        public string O { get; set; }
        public string POBox { get; set; }
        public string STREET { get; set; }
        public string L { get; set; }
        public string S { get; set; }
        public string PostalCode { get; set; }
        public string C { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PublicKey { get; set; }
        public string KeySize { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sigalg { get; set; }
    }
}
