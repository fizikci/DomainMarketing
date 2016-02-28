namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic info command message class
    /// </summary>
    /// <typeparam name="TInfoArgs">Target info class (represents object specific "info" element in command)</typeparam>
    /// <typeparam name="TInfoResult">Target info result class (represents object specific "infData" element in response)</typeparam>
    [Serializable]
    public class InfoCommandMessage<TInfoArgs, TInfoResult> :
        CommandMessage<InfoCommand<TInfoArgs, TInfoResult>, InfoResponse<TInfoResult>>
        where TInfoArgs : class, ICommandArgs<TInfoArgs, TInfoResult>
        where TInfoResult : class, ICommandResult<TInfoResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the InfoCommandMessage class with specified client transaction identifier and info object
        /// </summary>
        /// <param name="clientTranId">Сlient transaction identifier</param>
        /// <param name="info">Info object</param>
        public InfoCommandMessage(string clientTranId, TInfoArgs info)
            : base(CommandType.Info, clientTranId, new InfoCommand<TInfoArgs, TInfoResult>(info))
        {
        }

        /// <summary>
        /// Initializes a new instance of the InfoCommandMessage class with specified info object
        /// </summary>
        /// <param name="info">Info object</param>
        public InfoCommandMessage(TInfoArgs info)
            : base(CommandType.Info, null, new InfoCommand<TInfoArgs, TInfoResult>(info))
        {
        }
    }
}
