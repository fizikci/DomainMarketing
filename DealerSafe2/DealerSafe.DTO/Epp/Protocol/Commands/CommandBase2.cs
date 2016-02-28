namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Represents the EPP base command class
    /// </summary>
    /// <typeparam name="TCommandArgs">Target command class (represents object specific element in command)</typeparam>
    /// <typeparam name="TCommandResult">Target command result data class</typeparam>
    [Serializable]
    public abstract class CommandBase<TCommandArgs, TCommandResult> : CommandBase<TCommandArgs>
        where TCommandArgs : class, ICommandArgs<TCommandArgs>
        where TCommandResult : class, ICommandResult<TCommandResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the CommandBase class with specified command arguments
        /// </summary>
        /// <param name="args">Command object</param>
        protected CommandBase(TCommandArgs args)
            : base(args)
        {
        }
    }
}