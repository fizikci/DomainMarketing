namespace Epp.Protocol.Commands
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Base interface for all commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Must fill specified command message with this command content
        /// </summary>
        /// <param name="command">Filling command</param>
        void FillCommand(CommandMessageBase command);

        /// <summary>
        /// Gets command specific element
        /// </summary>
        /// <returns>Command specific element</returns>
        XElement GetCommandElement();
    }
}