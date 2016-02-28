namespace Epp.Protocol.Commands
{
    using System.Xml.Linq;

    /// <summary>
    /// Base interface for all responses
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Must extract response content from underlying response message
        /// </summary>
        /// <param name="response">Кesponse message</param>
        void ExtractResult(ResponseMessageBase response);

        /// <summary>
        /// Returns XElement that represents response specific result element
        /// </summary>
        /// <returns>XElement that represents response specific result element</returns>
        XElement GetResultElement();
    }
}