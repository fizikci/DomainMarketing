namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic delete command message class
    /// </summary>
    /// <typeparam name="TDeleteArgs">Target delete class (represents object specific "delete" element in command)</typeparam>
    [Serializable]
    public class DeleteCommandMessage<TDeleteArgs> :
        NoResCommandMessage<DeleteCommand<TDeleteArgs>>
        where TDeleteArgs : class, ICommandArgs<TDeleteArgs>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteCommandMessage class with specified client transaction identifier and delete object
        /// </summary>
        /// <param name="clientTranId">Сlient transaction identifier</param>
        /// <param name="delete">Delete object</param>
        public DeleteCommandMessage(string clientTranId, TDeleteArgs delete)
            : base(CommandType.Delete, clientTranId, new DeleteCommand<TDeleteArgs>(delete))
        {
        }

        /// <summary>
        /// Initializes a new instance of the DeleteCommandMessage class with specified delete object
        /// </summary>
        /// <param name="delete">Delete object</param>
        public DeleteCommandMessage(TDeleteArgs delete)
            : base(CommandType.Delete, null, new DeleteCommand<TDeleteArgs>(delete))
        {
        }
    }
}