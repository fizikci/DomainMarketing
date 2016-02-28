namespace Epp.Protocol
{
    using System.Xml.Linq;

    /// <summary>
    /// Base interface for all EPP response extension objects
    /// </summary>
    public interface IResponseExtension
    {
        /// <summary>
        /// Extracts data from specified "extension" XML element of the response
        /// </summary>
        /// <param name="extensionElement">"extension" XML element</param>
        void Extract(XElement extensionElement);
    }
}