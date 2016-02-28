namespace Epp.Protocol.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    /// <summary>
    /// Base class for all command result objects
    /// </summary>
    /// <typeparam name="TResult">Target command result data class</typeparam>
    [Serializable]
    public abstract class CommandResult<TResult> : ICommandResult<TResult>
        where TResult : CommandResult<TResult>, new()
    {
        /// <summary>
        /// Gets collection of response extensions
        /// </summary>
        public List<object> Extensions
        {
            get;
            set;
        }

        /// <summary>
        /// Must extract results from specified underlying response object
        /// </summary>
        /// <param name="response">Command response</param>
        public virtual void ExtractResult(ResponseBase<TResult> response)
        {
            this.Extensions = response.Extensions.ToList();
        }

        /// <summary>
        /// Extracts object specific response extension
        /// </summary>
        /// <typeparam name="T">Target extension type</typeparam>
        /// <returns>Object specific response extension</returns>
        public T Extension<T>() where T : IResponseExtension, new()
        {
            return this.Extensions.OfType<T>().FirstOrDefault();
        }
    }
}
