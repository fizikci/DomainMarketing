namespace Epp.Protocol.SecDns
{
    using System;

    /// <summary>
    /// DNSKEY record flags
    /// </summary>
    [Serializable]
    [Flags]
    public enum KeyDataFlags : ushort
    {
        /// <summary>
        /// DNSKEY record holds a DNS zone key
        /// </summary>
        IsZoneKey = 128,

        /// <summary>
        /// DNSKEY record holds a key intended for use as a secure entry point
        /// </summary>
        IsSecureEntryPoint = 32768
    }
}