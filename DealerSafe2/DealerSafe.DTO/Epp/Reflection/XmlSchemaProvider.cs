namespace Epp.Reflection
{
    using System.Collections.Generic;

    /// <summary>
    /// Base class for all XML Schema providers
    /// </summary>
    public abstract class XmlSchemaProvider
    {
        /// <summary>
        /// Returns sequence of text contents of XML schemas
        /// </summary>
        /// <returns>Sequence of text contents of XML schemas</returns>
        public abstract IEnumerable<string> GetSchemas();
    }
}