namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Represents the EPP renew command 
    /// </summary>
    /// <typeparam name="TRenewArgs">Target renew class (represents object specific "renew" element in command)</typeparam>
    /// <typeparam name="TRenewResult">Target renew result class (represents object specific "renData" element in response)</typeparam>
    [Serializable]
    public class RenewCommand<TRenewArgs, TRenewResult> : CommandBase<TRenewArgs, TRenewResult>
        where TRenewArgs : class, ICommandArgs<TRenewArgs, TRenewResult>
        where TRenewResult : class, ICommandResult<TRenewResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the RenewCommand class with specified renew object
        /// </summary>
        /// <param name="args">Renew command arguments object</param>
        public RenewCommand(TRenewArgs args)
            : base(args)
        {
        }

        /// <summary>
        /// Gets the name of the command specific element
        /// </summary>
        protected override string CommandElementName
        {
            get { return "renew"; }
        }
    }
}