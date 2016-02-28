namespace Epp.Protocol
{
    using System.Xml.Linq;

    /// <summary>
    /// Base interface for all EPP extension objects
    /// </summary>
    public interface IEppExtension
    {
        /// <summary>
        /// Extracts data from specified object XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        void Extract(XElement objectElement);
    }
}
