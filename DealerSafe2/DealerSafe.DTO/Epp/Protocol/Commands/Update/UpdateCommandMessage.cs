namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic update command message class
    /// </summary>
    /// <typeparam name="TUpdateArgs">Represents object specific "update" element in command</typeparam>
    [Serializable]
    public class UpdateCommandMessage<TUpdateArgs> :
        NoResCommandMessage<UpdateCommand<TUpdateArgs>>
        where TUpdateArgs : class, ICommandArgs<TUpdateArgs>
    {
         /// <summary>
        /// Initializes a new instance of the UpdateCommandMessage class with specified client transaction identifier and update object
        /// </summary>
        /// <param name="clientTranId">Сlient transaction identifier</param>
        /// <param name="update">Update object</param>
        public UpdateCommandMessage(string clientTranId, TUpdateArgs update)
            : base(CommandType.Update, clientTranId, new UpdateCommand<TUpdateArgs>(update))
        {
        }

        /// <summary>
        /// Initializes a new instance of the UpdateCommandMessage class with specified update object
        /// </summary>
        /// <param name="update">Update object</param>
        public UpdateCommandMessage(TUpdateArgs update)
            : base(CommandType.Update, null, new UpdateCommand<TUpdateArgs>(update))
        {
        }
    }
}
