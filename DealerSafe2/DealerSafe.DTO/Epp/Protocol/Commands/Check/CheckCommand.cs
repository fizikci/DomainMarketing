namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic check command class
    /// </summary>
    /// <typeparam name="TCheckArgs">Target check class (represents object specific "check" element in command)</typeparam>
    /// <typeparam name="TCheckResult">Target check data class (represents object specific "chkData" element in response) </typeparam>
    [Serializable]
    public class CheckCommand<TCheckArgs, TCheckResult> : CommandBase<TCheckArgs, TCheckResult>
        where TCheckArgs : class, ICommandArgs<TCheckArgs, TCheckResult>
        where TCheckResult : class, ICommandResult<TCheckResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the CheckCommand class with specified check object
        /// </summary>
        /// <param name="args">Check object</param>
        public CheckCommand(TCheckArgs args)
            : base(args)
        {
        }

        /// <summary>
        /// Gets the name of the command specific element
        /// </summary>
        protected override string CommandElementName
        {
            get { return "check"; }
        }
    }
}