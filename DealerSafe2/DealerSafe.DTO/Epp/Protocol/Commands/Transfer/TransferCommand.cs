namespace Epp.Protocol.Commands
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Represents the EPP transfer command 
    /// </summary>
    /// <typeparam name="TTransferArgs">Target transfer class (represents object specific "transfer" element in command)</typeparam>
    /// <typeparam name="TTransferResult">Target transfer result class (represents object specific "trnData" element in response)</typeparam>
    [Serializable]
    public class TransferCommand<TTransferArgs, TTransferResult> : CommandBase<TTransferArgs, TTransferResult>
        where TTransferArgs : class, ICommandArgs<TTransferArgs, TTransferResult>
        where TTransferResult : class, ICommandResult<TTransferResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the TransferCommand class with specified transfer object as request operation
        /// </summary>
        /// <param name="args">Transfer object</param>
        public TransferCommand(TTransferArgs args)
            : base(args)
        {
            this.Operation = TransferOperation.Request;
        }

        /// <summary>
        /// Initializes a new instance of the TransferCommand class with specified transfer object and specified operation
        /// </summary>
        /// <param name="args">Transfer object</param>
        /// <param name="op">Transfer operation</param>
        public TransferCommand(TTransferArgs args, TransferOperation op)
            : base(args) {
            this.Operation = op;
        }

        /// <summary>
        /// Gets transfer operation
        /// </summary>
        public TransferOperation Operation { get; set; }

        /// <summary>
        /// Gets the name of the command specific element
        /// </summary>
        protected override string CommandElementName
        {
            get { return "transfer"; }
        }

        /// <summary>
        /// Fill specified transfer command message with this transfer command content
        /// </summary>
        /// <param name="command">Filling command</param>
        public override void FillCommand(CommandMessageBase command)
        {
            base.FillCommand(command);

            var operationAttr = new XAttribute("op", this.Operation.ToString().ToLowerInvariant());
            this.GetCommandElement().Add(operationAttr);
        }
    }
}