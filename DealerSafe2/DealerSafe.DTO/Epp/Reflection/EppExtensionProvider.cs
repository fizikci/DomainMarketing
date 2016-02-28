namespace Epp.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Basic class of all EPP extension providers
    /// </summary>
    public abstract class EppExtensionProvider
    {
        /// <summary>
        /// Returns a sequence of the pairs of extesion object XML element name and extension object type
        /// </summary>
        /// <returns>Sequence of the pairs of extesion object XML element name and extension object type</returns>
        public abstract IEnumerable<KeyValuePair<XName, Type>> GetExtensions();
    }
}