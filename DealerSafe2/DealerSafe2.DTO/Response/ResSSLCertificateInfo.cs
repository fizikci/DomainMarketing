using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.Response
{
    public class ResSSLCertificateInfo
    {
        public string serial { get; set; }

        public Issuer issuer { get; set; }

        public Subject subject { get; set; }

        public string notBefore { get; set; }

        public string notAfter { get; set; }
    }

    public class Issuer
    {
        /// <summary>
        /// Common Name
        /// </summary>
        public string CN { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string C { get; set; }

        /// <summary>
        /// Organization
        /// </summary>
        public string O { get; set; }

        /// <summary>
        /// Locality
        /// </summary>
        public string L { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string ST { get; set; }
    }

    public class Subject
    {
        /// <summary>
        /// Common Name
        /// </summary>
        public string CN { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string C { get; set; }

        /// <summary>
        /// Organization
        /// </summary>
        public string O { get; set; }

        /// <summary>
        /// Locality
        /// </summary>
        public string L { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string ST { get; set; }
    }
}
