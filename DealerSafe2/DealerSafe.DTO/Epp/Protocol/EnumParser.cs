namespace Epp.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Helper class for enum parsing
    /// </summary>
    public static class EnumParser
    {
        /// <summary>
        /// Converts string name of enum member to enum type
        /// </summary>
        /// <typeparam name="T">Target enum type</typeparam>
        /// <param name="str">Value to convert</param>
        /// <returns>Converted enum value</returns>
        public static T ToEnum<T>(this string str)
            where T : struct
        {
            var lowStr = str.ToLowerInvariant();
            return EnumValuesStore<T>.Values[lowStr];
        }

        /// <summary>
        /// Holds dictionary of enum values of T keyed by lovercase names
        /// </summary>
        /// <typeparam name="T">Target enum type</typeparam>
        private static class EnumValuesStore<T> where T : struct
        {
            /// <summary>
            /// Dictionary of enum values of T keyed by lovercase names
            /// </summary>
            public static readonly Dictionary<string, T> Values = Enum
                .GetNames(typeof(T))
                .ToDictionary(name => name.ToLower(new System.Globalization.CultureInfo("en-US")), name => (T)Enum.Parse(typeof(T), name));
        }
    }
}