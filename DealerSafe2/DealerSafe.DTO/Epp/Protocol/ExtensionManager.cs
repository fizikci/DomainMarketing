namespace Epp.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Reflection;

    /// <summary>
    /// Helps discover and create EPP protocol extension objects
    /// </summary>
    public static class ExtensionManager
    {
        /// <summary>
        /// Dictionary of extension types by XML element names
        /// </summary>
        private static readonly Dictionary<XName, Type> providers = EppExtensionDiscoverer.GetExtensions()
            .ToDictionary(ext => ext.Key, ext => ext.Value);

        /// <summary>
        /// Creates EPP protocol extension object from specified object XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        /// <returns>EPP protocol extension object or null if no extension found</returns>
        public static object CreateObject(XElement objectElement)
        {
            Type objectType;
            if (providers.TryGetValue(objectElement.Name, out objectType))
            {
                var obj = (IEppExtension)Activator.CreateInstance(objectType);
                obj.Extract(objectElement);
                return obj;
            }

            return null;
        }
    }
}
