using System.Security.Cryptography;
using System.Text;

namespace Epp.Protocol.SecDns
{
    using System;

    /// <summary>
    /// Describe the delegation signer data provided by the client for the domain
    /// </summary>
    [Serializable]
    public class DelegationSignerData
    {
        private static string flags = "256";
        private static string protocol = "3";
        private static string alg = "1";
        private static string publicKey = "";

        /// <summary>
        /// Initializes a new instance of the DelegationSignerData class
        /// </summary>
        /// <param name="keyTag">Key tag of the DNSKEY RR referred to by the DS record, in network byte order</param>
        /// <param name="algorithm">Type of the algorithm of the DNSKEY RR referred to by the DS record</param>
        /// <param name="digest">Digest of the referred DNSKEY RR</param>
        public DelegationSignerData(ushort keyTag, AlgorithmType algorithm, byte[] digest)
        {
            this.KeyTag = keyTag;
            this.Algorithm = algorithm;
            this.DigestType = DigestType.SHA1;
            this.Digest = digest;
        }

        /// <summary>
        /// Initializes a new instance of the DelegationSignerData class
        /// </summary>
        /// <param name="keyTag">Key tag of the DNSKEY RR referred to by the DS record, in network byte order</param>
        /// <param name="algorithm">Type of the algorithm of the DNSKEY RR referred to by the DS record</param>
        /// <param name="digest">Digest of the referred DNSKEY RR in HEX string format</param>
        public DelegationSignerData(ushort keyTag, AlgorithmType algorithm, string digest)
            : this(keyTag, algorithm, digest.ToHexBinary())
        {
        }
        /// <summary>
        /// Initializes a new instance of the DelegationSignerData class
        /// and create digest with default algotrithm SHA1
        /// </summary>
        /// <param name="keyTag">Key tag of the DNSKEY RR referred to by the DS record, in network byte order</param>
        /// <param name="domainName">Domain name for which digest is generated</param>
        public DelegationSignerData(ushort keyTag, string domainName)
        {
            var rdata = String.Concat(flags, protocol, alg, publicKey);
            String digestString = String.Concat(domainName, rdata);
            var digest = CalculateSHA1(digestString, Encoding.ASCII);
            this.KeyTag = keyTag;
            this.Algorithm = AlgorithmType.DSASHA1;
            this.DigestType = DigestType.SHA1;
            Digest = digest.ToHexBinary();
        }

        private string CalculateSHA1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 =
            new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(
                cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
            return hash;
        }
        /// <summary>
        /// Gets key tag of the DNSKEY RR referred to by the DS record, in network byte order
        /// </summary>
        public ushort KeyTag { get; set; }

        /// <summary>
        /// Gets the type of the algorithm of the DNSKEY RR referred to by the DS record
        /// </summary>
        public AlgorithmType Algorithm { get; set; }

        /// <summary>
        /// Gets the value identified the algorithm used to construct the digest
        /// </summary>
        public DigestType DigestType { get; set; }

        /// <summary>
        /// Gets the digest of the referred DNSKEY RR
        /// </summary>
        public byte[] Digest { get; set; }

        /// <summary>
        /// Gets the digest of the referred DNSKEY RR as HEX string
        /// </summary>
        public string DigestString
        {
            get
            {
                return this.Digest.ToHexString();
            }
        }

        /// <summary>
        /// Gets or sets the value that indicates a child's preference for the number of seconds after signature generation when the parent's signature on the DS information provided by the child will expire 
        /// </summary>
        public int? MaxSigLife { get; set; }

        /// <summary>
        /// Gets or sets the value that describes the key data used as input in the DS hash calculation
        /// </summary>
        public KeyData KeyData { get; set; }
    }
}
