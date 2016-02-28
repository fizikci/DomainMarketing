namespace Epp.Protocol.Commands
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents poll extensions helper
    /// </summary>
    [Serializable]
    public static class PollExtensions
    {
        /// <summary>
        /// Extracts poll command result extension
        /// </summary>
        /// <typeparam name="T">Target extension object type</typeparam>
        /// <param name="responseMessage">Response message of the poll command</param>
        /// <returns>Poll command result extension object or null</returns>
        public static T PollExtension<T>(this ResponseMessageBase responseMessage)
        {
            if (responseMessage.ResponseDataElement == null)
            {
                return default(T);
            }

            var objectElement = responseMessage.ResponseDataElement.Elements().FirstOrDefault();
            if (objectElement == null)
            {
                return default(T);
            }

            return (T)ExtensionManager.CreateObject(objectElement);
        }
    }
}