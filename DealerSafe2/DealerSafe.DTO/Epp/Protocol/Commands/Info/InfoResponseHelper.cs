namespace Epp.Protocol.Commands
{
    using System;
    using System.Linq;

    /// <summary>
    /// Helps extract the ROID from info command response
    /// </summary>
    [Serializable]
    internal static class InfoResponseHelper
    {
        /// <summary>
        /// Gets the ROID from info command response
        /// </summary>
        /// <param name="response">Response object of info command</param>
        /// <returns>ROID of the retrieving object</returns>
        public static string GetRoid(this IResponse response)
        {
            return response
                .GetResultElement()
                .Elements()
                .Where(elem => elem.Name.LocalName == "roid")
                .FirstOrDefault().Value;
        }
    }
}