namespace Epp.Reflection
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Helps discover all XML schemas in all referenced by current AppDomain assemblies
    /// </summary>
    internal static class XmlSchemaDiscoverer
    {
        /// <summary>
        /// Discover all XML schemas in the current AppDomain
        /// </summary>
        /// <returns>Sequence of XML schema text contents</returns>
        public static List<string> GetSchemas()
        {
            return ReflectionExtensions
                .GetDomainReferencedAssemblies()
                .SelectMany(assembly => assembly.GetCustomAttributes(typeof(XmlSchemaProviderAttribute), false))
                .OfType<XmlSchemaProviderAttribute>()
                .SelectMany(attr => attr.GetProvider().GetSchemas()).ToList();
        }
    }
}