namespace Epp.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Helps convert binaries to HEX-strings and HEX-strings back to binaries
    /// </summary>
    internal static class HexByteConverter
    {
        /// <summary>
        /// String representations of the half of bytes
        /// </summary>
        private static readonly string[] halfBytes =
            new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

        /// <summary>
        /// String representations of the bytes
        /// </summary>
        private static readonly string[] bytes = Enumerable
            .Range(0, 256)
            .Select(index => halfBytes[index >> 4] + halfBytes[index & 0xf])
            .ToArray();

        /// <summary>
        /// Dictionary of bytes by HEX-strings
        /// </summary>
        private static readonly Dictionary<string, byte> bytesBack = Enumerable
            .Range(0, 256)
            .ToDictionary(index => bytes[index], index => (byte)index);

        /// <summary>
        /// Converts binary value to HEX-string
        /// </summary>
        /// <param name="value">Converting value</param>
        /// <returns>HEX-string representation of the binary value</returns>
        public static string ToHexString(this byte[] value)
        {
            var valueLen = value.Length;
            return String.Concat(Enumerable.Range(1, valueLen)
                .Select(index => bytes[value[valueLen - index]])
                .ToArray());
        }

        /// <summary>
        /// Converts HEX-string value to the binary
        /// </summary>
        /// <param name="value">Converting value</param>
        /// <returns>Binary representation of the HEX-string value</returns>
        public static byte[] ToHexBinary(this string value)
        {
            value = value.ToUpper();
            var valueLen = value.Length;
            return Enumerable.Range(0, valueLen >> 1)
                .Select(index => bytesBack[value.Substring(valueLen - (index << 1) - 2, 2)])
                .ToArray();
        }
    }
}
