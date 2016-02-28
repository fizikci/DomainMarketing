namespace Epp.Protocol.SecDns
{
    using System;

    /// <summary>
    /// Identifies the algorithm used to construct the digest
    /// </summary>
    [Serializable]
    public enum DigestType : byte
    {
        /// <summary>
        /// SHA-1 algorithm
        /// </summary>
        SHA1 = 1
    }
}
