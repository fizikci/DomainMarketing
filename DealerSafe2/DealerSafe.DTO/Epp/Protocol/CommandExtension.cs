namespace Epp.Protocol
{
    using System.Xml.Linq;

    /// <summary>
    /// Base interface for all EPP command extension objects
    /// </summary>
    public interface ICommandExtension
    {
        /// <summary>
        /// Fills specified "extension" XML element of the command
        /// </summary>
        /// <param name="extensionElement">"extension" XML element</param>
        void Fill(XElement extensionElement);
    }
}