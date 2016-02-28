namespace Epp.Protocol.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Helps extract the "cd" items from check command response
    /// </summary>
    [Serializable]
    internal static class CheckResponseHelper
    {
        /// <summary>
        /// Extracts the "cd" items from check command response
        /// </summary>
        /// <param name="response">Check command response</param>
        /// <returns>Sequence of the "cd" items</returns>
        public static List<CDItem> GetCDItems(this IResponse response)
        {
            return response.GetResultElement()
                .Elements()
                .Where(elem => elem.Name.LocalName == "cd")
                .Select(cdElem => new CDItem(cdElem))
                .ToList();
        }
    }
}