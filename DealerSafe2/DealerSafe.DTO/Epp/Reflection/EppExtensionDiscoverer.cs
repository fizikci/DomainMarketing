namespace Epp.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Helps discover all EPP extension providers in all referenced by current AppDomain assemblies
    /// </summary>
    internal static class EppExtensionDiscoverer
    {
        /// <summary>
        /// Discover all EPP extension providers in current AppDomain
        /// </summary>
        /// <returns>Sequence of EPP extension providers</returns>
        public static List<KeyValuePair<XName, Type>> GetExtensions()
        {
            return ReflectionExtensions
                .GetDomainReferencedAssemblies()
                .SelectMany(assembly => assembly.GetCustomAttributes(typeof(EppExtensionProviderAttribute), false))
                .OfType<EppExtensionProviderAttribute>()
                .SelectMany(attr => attr.GetProvider().GetExtensions()).ToList();
        }
    }
}