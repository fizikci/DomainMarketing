namespace Epp.Protocol.Commands
{
    /// <summary>
    /// Base interface for all command argumen objects
    /// </summary>
    /// <typeparam name="TArgs">Target update class</typeparam>
    public interface ICommandArgs<TArgs>
        where TArgs : class, ICommandArgs<TArgs>
    {
        /// <summary>
        /// Must fill specified command with content
        /// </summary>
        /// <param name="command">Filling command</param>
        void FillCommand(ICommand command);
    }

    /// <summary>
    /// Base interface for all command argument objects
    /// </summary>
    /// <typeparam name="TArgs">Target command argument class</typeparam>
    /// <typeparam name="TResult">Target command result class</typeparam>
    public interface ICommandArgs<TArgs, TResult> : ICommandArgs<TArgs>
        where TArgs : class, ICommandArgs<TArgs, TResult>
        where TResult : class, ICommandResult<TResult>, new()
    {
    }
}