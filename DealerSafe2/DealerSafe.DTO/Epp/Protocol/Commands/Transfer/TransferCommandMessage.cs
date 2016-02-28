namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic transfer command message class
    /// </summary>
    /// <typeparam name="TTransferArgs">Target transfer class (represents object specific "transfer" element in command)</typeparam>
    /// <typeparam name="TTransferResult">Target transfer result class (represents object specific "trnData" element in response)</typeparam>
    [Serializable]
    public class TransferCommandMessage<TTransferArgs, TTransferResult> :
        CommandMessage<TransferCommand<TTransferArgs, TTransferResult>, TransferResponse<TTransferResult>>
        where TTransferArgs : class, ICommandArgs<TTransferArgs, TTransferResult>
        where TTransferResult : class, ICommandResult<TTransferResult>, new() {
        /// <summary>
        /// Initializes a new instance of the TransferCommandMessage class with specified client transaction identifier and transfer object as request operation
        /// </summary>
        /// <param name="clientTranId">Сlient transaction identifier</param>
        /// <param name="transfer">Transfer object</param>
        public TransferCommandMessage(string clientTranId, TTransferArgs transfer)
            : base(CommandType.Transfer, clientTranId, new TransferCommand<TTransferArgs, TTransferResult>(transfer)) {
        }

        /// <summary>
        /// Initializes a new instance of the TransferCommandMessage class with specified transfer object as request operation
        /// </summary>
        /// <param name="transfer">Transfer object</param>
        public TransferCommandMessage(TTransferArgs transfer)
            : base(CommandType.Transfer, null, new TransferCommand<TTransferArgs, TTransferResult>(transfer)) {
        }

        /// <summary>
        /// Initializes a new instance of the TransferCommandMessage class with specified client transaction identifier, transfer object and transfer operation
        /// </summary>
        /// <param name="clientTranId">Сlient transaction identifier</param>
        /// <param name="transfer">Transfer object</param>
        /// <param name="op">Transfer operation</param>
        public TransferCommandMessage(string clientTranId, TTransferArgs transfer, TransferOperation op)
            : base(CommandType.Transfer, clientTranId, new TransferCommand<TTransferArgs, TTransferResult>(transfer, op)) {
        }

        /// <summary>
        /// Initializes a new instance of the TransferCommandMessage class with specified transfer object and transfer operation
        /// </summary>
        /// <param name="transfer">Transfer object</param>
        /// /// <param name="op">Transfer operation</param>
        public TransferCommandMessage(TTransferArgs transfer, TransferOperation op)
            : base(CommandType.Transfer, null, new TransferCommand<TTransferArgs, TTransferResult>(transfer, op)) {
        }
    }
}
