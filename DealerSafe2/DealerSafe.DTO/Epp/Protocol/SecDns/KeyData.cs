namespace Epp.Protocol.SecDns
{
    using System;

    /// <summary>
    /// Describe the key data used as input in the DS hash calculation
    /// </summary>
    [Serializable]
    public class KeyData
    {
        /// <summary>
        /// Initializes a new instance of the KeyData class
        /// </summary>
        /// <param name="flags">DNSKEY record flags</param>
        /// <param name="algorithm">Identifies the public key's cryptographic algorithm and determines the format of the Public Key field</param>
        /// <param name="publicKey">Holds the public key material</param>
        public KeyData(KeyDataFlags flags, AlgorithmType algorithm, byte[] publicKey)
        {
            this.Flags = flags;
            this.Algorithm = algorithm;
            this.PublicKey = publicKey;
        }

        /// <summary>
        /// Gets DNSKEY record flags
        /// </summary>
        public KeyDataFlags Flags { get; set; }

        /// <summary>
        /// Gets the value 3 (http://tools.ietf.org/html/rfc4034#page-5)
        /// </summary>
        public byte Protocol
        {
            get
            {
                return 3;
            }
        }

        /// <summary>
        /// Gets the value identified the public key's cryptographic algorithm and determines the format of the Public Key field
        /// </summary>
        public AlgorithmType Algorithm { get; set; }

        /// <summary>
        /// Gets the value hold the public key material
        /// </summary>
        public byte[] PublicKey { get; set; }
    }
}