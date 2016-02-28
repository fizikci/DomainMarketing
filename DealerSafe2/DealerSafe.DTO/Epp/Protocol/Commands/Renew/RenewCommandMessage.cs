namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic renew command message class
    /// </summary>
    /// <typeparam name="TRenewArgs">Target renew class (represents object specific "renew" element in command)</typeparam>
    /// <typeparam name="TRenewResult">Target renew result class (represents object specific "renData" element in response)</typeparam>
    [Serializable]
    public class RenewCommandMessage<TRenewArgs, TRenewResult> :
        CommandMessage<RenewCommand<TRenewArgs, TRenewResult>, RenewResponse<TRenewResult>>
        where TRenewArgs : class, ICommandArgs<TRenewArgs, TRenewResult>
        where TRenewResult : class, ICommandResult<TRenewResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the RenewCommandMessage class with specified client transaction identifier and renew object
        /// </summary>
        /// <param name="clientTranId">Сlient transaction identifier</param>
        /// <param name="renew">Renew object</param>
        public RenewCommandMessage(string clientTranId, TRenewArgs renew)
            : base(CommandType.Renew, clientTranId, new RenewCommand<TRenewArgs, TRenewResult>(renew))
        {
        }

        /// <summary>
        /// Initializes a new instance of the RenewCommandMessage class with specified renew object
        /// </summary>
        /// <param name="renew">Renew object</param>
        public RenewCommandMessage(TRenewArgs renew)
            : base(CommandType.Renew, null, new RenewCommand<TRenewArgs, TRenewResult>(renew))
        {
        }
    }
}
