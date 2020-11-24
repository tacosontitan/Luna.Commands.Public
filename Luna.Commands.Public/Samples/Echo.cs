using Luna.Core;

namespace Luna.Commands.Public.Samples {
    /// <summary>
    /// A simple echo command used to demonstrate how to setup new commands.
    /// </summary>
    /// <remarks>All commands must be public, and they must derive from `LunarCommand`. We also recommend marking commands as sealed to prevent inheritance.</remarks>
    public sealed class Echo : LunarCommand {

        #region Constructors

        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public Echo() : base("samples.echo", false) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(object[] parameters) {
            // In this sample, we want to simply return what the user supplied.
            if (parameters.Length >= 1)
                return string.Join(" ", parameters);
            else if (parameters.Length == 0)
                return parameters[0].ToString();
            else
                return "No input provided to echo.";
        }

        #endregion

    }
}
