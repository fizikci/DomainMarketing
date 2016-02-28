namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Represents the EPP info command 
    /// </summary>
    /// <typeparam name="TInfoArgs">Target info class (represents object specific "info" element in command)</typeparam>
    /// <typeparam name="TInfoResult">Target info result class (represents object specific "infData" element in response)</typeparam>
    [Serializable]
    public class InfoCommand<TInfoArgs, TInfoResult> : CommandBase<TInfoArgs, TInfoResult>
        where TInfoArgs : class, ICommandArgs<TInfoArgs, TInfoResult>
        where TInfoResult : class, ICommandResult<TInfoResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the InfoCommand class with specified info object
        /// </summary>
        /// <param name="args">Info command arguments object</param>
        public InfoCommand(TInfoArgs args)
            : base(args)
        {
        }

        /// <summary>
        /// Gets the name of the command specific element
        /// </summary>
        protected override string CommandElementName
        {
            get { return "info"; }
        }
    }
}