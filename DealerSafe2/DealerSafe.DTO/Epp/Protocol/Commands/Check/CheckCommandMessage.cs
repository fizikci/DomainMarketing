namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic check command message class
    /// </summary>
    /// <typeparam name="TCheckArgs">Target check class (represents object specific "check" element in command)</typeparam>
    /// <typeparam name="TCheckResult">Target check data class (represents object specific "chkData" element in response) </typeparam>
    [Serializable]
    public class CheckCommandMessage<TCheckArgs, TCheckResult> :
        CommandMessage<CheckCommand<TCheckArgs, TCheckResult>, CheckResponse<TCheckResult>>
        where TCheckArgs : class, ICommandArgs<TCheckArgs, TCheckResult>
        where TCheckResult : class, ICommandResult<TCheckResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the CheckCommandMessage class with specified client transaction identifier and check object
        /// </summary>
        /// <param name="clientTranId">Сlient transaction identifier</param>
        /// <param name="check">Check object</param>
        public CheckCommandMessage(string clientTranId, TCheckArgs check)
            : base(CommandType.Check, clientTranId, new CheckCommand<TCheckArgs, TCheckResult>(check))
        {
        }

        /// <summary>
        /// Initializes a new instance of the CheckCommandMessage class with specified check object
        /// </summary>
        /// <param name="check">Check object</param>
        public CheckCommandMessage(TCheckArgs check)
            : base(CommandType.Check, null, new CheckCommand<TCheckArgs, TCheckResult>(check))
        {
        }
    }
}