namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic delete command class
    /// </summary>
    /// <typeparam name="TDeleteArgs">Target delete class (represents object specific "delete" element in command)</typeparam>
    [Serializable]
    public class DeleteCommand<TDeleteArgs> : CommandBase<TDeleteArgs>
        where TDeleteArgs : class, ICommandArgs<TDeleteArgs>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteCommand class with specified create object
        /// </summary>
        /// <param name="args">Delete object</param>
        public DeleteCommand(TDeleteArgs args)
            : base(args)
        {
        }

        /// <summary>
        /// Gets the name of the command specific element
        /// </summary>
        protected override string CommandElementName
        {
            get { return "delete"; }
        }
    }
}