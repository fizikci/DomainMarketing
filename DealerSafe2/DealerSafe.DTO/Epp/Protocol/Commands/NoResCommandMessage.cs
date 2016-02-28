namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic command message class with no response
    /// </summary>
    /// <typeparam name="TCommand">Target command class</typeparam>
    [Serializable]
    public class NoResCommandMessage<TCommand> : CommandMessageBase
        where TCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the NoResCommandMessage class with specidfied command type, client transaction identifier and command object
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="clientTranId">Client transaction identifier</param>
        /// <param name="command">Command object</param>
        public NoResCommandMessage(CommandType commandType, string clientTranId, TCommand command)
            : base(commandType, false, clientTranId)
        {
            this.Command = command;
            command.FillCommand(this);
        }

        /// <summary>
        /// Gets command object
        /// </summary>
        public TCommand Command
        {
            get;
            set;
        }
    }
}
