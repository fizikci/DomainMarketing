namespace Epp.Reflection
{
    using System;

    /// <summary>
    /// Provides EPP extensions to application from extension assemblies
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class EppExtensionProviderAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the EppExtensionProviderAttribute class
        /// </summary>
        /// <param name="extensionProviderType">Type of the target extension provider class</param>
        public EppExtensionProviderAttribute(Type extensionProviderType)
        {
            if (extensionProviderType == null)
            {
                throw new ArgumentNullException("extensionProviderType");
            }

            if (!extensionProviderType.IsSubclassOf(typeof(EppExtensionProvider)))
            {
                throw new ArgumentOutOfRangeException("extensionProviderType");
            }

            this.ExtensionProviderType = extensionProviderType;
        }

        /// <summary>
        /// Gets the type of the target schema provider class
        /// </summary>
        public Type ExtensionProviderType { get; set; }

        /// <summary>
        /// Gets EPP extension provider
        /// </summary>
        /// <returns>EPP extension provider</returns>
        public EppExtensionProvider GetProvider()
        {
            return (EppExtensionProvider)Activator.CreateInstance(this.ExtensionProviderType);
        }
    }
}