using Luna.Core;

namespace Luna.Commands.Public.Samples {
    /// <summary>
    /// A simple hello world command used to demonstrate how to setup new commands.
    /// </summary>
    /// <remarks>All commands must be public, and they must derive from `LunarCommand`. We also recommend marking commands as sealed to prevent inheritance.</remarks>
    public sealed class HelloWorld : LunarCommand {

        #region Constructors


        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public HelloWorld() : base("samples.hello-world", false) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(object[] parameters) {
            // In this sample, we don't require any parameters.
            // We're simply going to say hello.
            return "Hello World";
        }

        #endregion

    }
}