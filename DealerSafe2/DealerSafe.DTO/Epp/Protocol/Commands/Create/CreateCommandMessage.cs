namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic create command message class
    /// </summary>
    /// <typeparam name="TCreateArgs">Target create class (represents object specific "create" element in command)</typeparam>
    /// <typeparam name="TCreateResult">Target create result class (represents object specific "creData" element in response) </typeparam>
    [Serializable]
    public class CreateCommandMessage<TCreateArgs, TCreateResult> :
        CommandMessage<CreateCommand<TCreateArgs, TCreateResult>, CreateResponse<TCreateResult>>
        where TCreateArgs : class, ICommandArgs<TCreateArgs, TCreateResult>
        where TCreateResult : class, ICommandResult<TCreateResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the CreateCommandMessage class with specified client transaction identifier and create object
        /// </summary>
        /// <param name="clientTranId">Сlient transaction identifier</param>
        /// <param name="create">Create object</param>
        public CreateCommandMessage(string clientTranId, TCreateArgs create)
            : base(CommandType.Check, clientTranId, new CreateCommand<TCreateArgs, TCreateResult>(create))
        {
        }

        /// <summary>
        /// Initializes a new instance of the CreateCommandMessage class with specified create object
        /// </summary>
        /// <param name="create">Create object</param>
        public CreateCommandMessage(TCreateArgs create)
            : base(CommandType.Check, null, new CreateCommand<TCreateArgs, TCreateResult>(create))
        {
        }
    }
}