namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic command message class
    /// </summary>
    /// <typeparam name="TCommand">Target command class</typeparam>
    /// <typeparam name="TResponse">Target response class</typeparam>
    [Serializable]
    public class CommandMessage<TCommand, TResponse> : CommandMessageBase
        where TCommand : ICommand
        where TResponse : IResponse
    {
        /// <summary>
        /// Initializes a new instance of the CommandMessage class with specidfied command type, client transaction identifier and command object
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="clientTranId">Client transaction identifier</param>
        /// <param name="command">Command object</param>
        public CommandMessage(CommandType commandType, string clientTranId, TCommand command)
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