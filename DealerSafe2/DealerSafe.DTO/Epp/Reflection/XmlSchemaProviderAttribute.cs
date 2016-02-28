namespace Epp.Reflection
{
    using System;

    /// <summary>
    /// Provides an XML schemas to application from extension assemblies
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class XmlSchemaProviderAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the XmlSchemaProviderAttribute class
        /// </summary>
        /// <param name="schemaProviderType">Type of the target schema provider class</param>
        public XmlSchemaProviderAttribute(Type schemaProviderType)
        {
            if (schemaProviderType == null)
            {
                throw new ArgumentNullException("schemaProviderType");
            }

            if (!schemaProviderType.IsSubclassOf(typeof(XmlSchemaProvider)))
            {
                throw new ArgumentOutOfRangeException("schemaProviderType");
            }

            this.SchemaProviderType = schemaProviderType;
        }

        /// <summary>
        /// Gets the type of the target schema provider class
        /// </summary>
        public Type SchemaProviderType { get; set; }

        /// <summary>
        /// Gets the schema provider
        /// </summary>
        /// <returns>Schema provider</returns>
        public XmlSchemaProvider GetProvider()
        {
            return (XmlSchemaProvider)Activator.CreateInstance(this.SchemaProviderType);
        }
    }
}