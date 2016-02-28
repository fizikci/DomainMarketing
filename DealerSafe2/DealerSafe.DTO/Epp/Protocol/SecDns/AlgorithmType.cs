namespace Epp.Protocol.SecDns
{
    using System;

    /// <summary>
    /// Type of the cryptographic algorithm
    /// </summary>
    [Serializable]
    public enum AlgorithmType : byte
    {
        /// <summary>
        /// RSA/MD5 algorithm
        /// </summary>
        RSAMD5 = 1,

        /// <summary>
        /// Diffie-Hellman algorithm
        /// </summary>
        DiffieHellman = 2,

        /// <summary>
        /// DSA/SHA-1 algorithm
        /// </summary>
        DSASHA1 = 3,

        /// <summary>
        /// Elliptic Curve algorithm
        /// </summary>
        EllipticCurve = 4,

        /// <summary>
        /// RSA/SHA-1 algorithm
        /// </summary>
        RSASHA1 = 5,

        /// <summary>
        /// Indirect algorithm
        /// </summary>
        Indirect = 252,

        /// <summary>
        /// Private [PRIVATEDNS] algorithm
        /// </summary>
        PrivateDNS = 253,

        /// <summary>
        /// Private [PRIVATEOID] algorithm
        /// </summary>
        PrivateOID = 254
    }
}