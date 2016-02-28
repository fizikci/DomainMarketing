namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic create command class
    /// </summary>
    /// <typeparam name="TCreateArgs">Target create class (represents object specific "create" element in command)</typeparam>
    /// <typeparam name="TCreateResult">Target create result class (represents object specific "creData" element in response) </typeparam>
    [Serializable] 
    public class CreateCommand<TCreateArgs, TCreateResult> : CommandBase<TCreateArgs, TCreateResult>
        where TCreateArgs : class, ICommandArgs<TCreateArgs, TCreateResult>
        where TCreateResult : class, ICommandResult<TCreateResult>, new()
    {
        /// <summary>
        /// Initializes a new instance of the CreateCommand class with specified create object
        /// </summary>
        /// <param name="args">Create arguments object</param>
        public CreateCommand(TCreateArgs args)
            : base(args)
        {
        }

        /// <summary>
        /// Gets the name of the command specific element
        /// </summary>
        protected override string CommandElementName
        {
            get { return "create"; }
        }
    }
}