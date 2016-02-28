namespace Epp.Protocol.Commands
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represents the EPP base command class
    /// </summary>
    /// <typeparam name="TCommandArgs">Target command class (represents object specific element in command)</typeparam>
    [Serializable]
    public abstract class CommandBase<TCommandArgs> : ICommand
        where TCommandArgs : class, ICommandArgs<TCommandArgs>
    {
        /// <summary>
        /// Gets object specific command argument XML
        /// </summary>
        [NonSerialized]
        private XElement commandElement;

        /// <summary>
        /// Initializes a new instance of the CommandBase class with specified command arguments
        /// </summary>
        /// <param name="args">Command object</param>
        protected CommandBase(TCommandArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            this.Args = args;
        }

        /// <summary>
        /// Gets the command arguments object
        /// </summary>
        public TCommandArgs Args { get; set; }

        /// <summary>
        /// Gets the name of the command specific element
        /// </summary>
        protected abstract string CommandElementName { get; }

        #region ICommand Members

        /// <summary>
        /// Fills specified command message with this command content
        /// </summary>
        /// <param name="commandMessage">Filling command messaqe</param>
        public virtual void FillCommand(CommandMessageBase commandMessage)
        {
            this.commandElement = new XElement(MessageBase.EppNs.GetName(this.CommandElementName));
            commandMessage.CommandElement.AddFirst(this.commandElement);
            this.Args.FillCommand(this);
            var objInfoElement = this.commandElement
                .Elements()
                .FirstOrDefault(elem => elem.Name.LocalName == this.CommandElementName);
            if (objInfoElement == null)
            {
                throw new ArgumentException("Invalid command argument object");
            }
        }

        /// <summary>
        /// Gets command specific element
        /// </summary>
        /// <returns>Command specific element</returns>
        public XElement GetCommandElement()
        {
            return this.commandElement;
        }

        #endregion
    }
}