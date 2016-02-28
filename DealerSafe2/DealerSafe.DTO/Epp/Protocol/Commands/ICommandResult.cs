namespace Epp.Protocol.Commands
{
    /// <summary>
    /// Base interface for all command result objects
    /// </summary>
    /// <typeparam name="TResult">Target command result data class</typeparam>
    public interface ICommandResult<TResult>
        where TResult : class, ICommandResult<TResult>, new()
    {
        /// <summary>
        /// Must extract results from specified underlying response object
        /// </summary>
        /// <param name="response">Command response</param>
        void ExtractResult(ResponseBase<TResult> response);
    }
}