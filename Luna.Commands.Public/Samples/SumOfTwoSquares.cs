using Luna.Core;

namespace Luna.Commands.Public.Samples {
    /// <summary>
    /// A simple sum of two squares command used to demonstrate how to setup new commands.
    /// </summary>
    /// <remarks>All commands must be public, and they must derive from `LunarCommand`. We also recommend marking commands as sealed to prevent inheritance.</remarks>
    public sealed class SumOfTwoSquares : LunarCommand {

        #region Constructors

        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public SumOfTwoSquares() : base("samples.sum-squares", false) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(LunarUser sender, object[] parameters) {
            // In this sample, we're going to square and sum two parameters.
            // This sample only supports two parameters, no more, no less.
            if (parameters.Length != 2)
                return $"The required number of parameters supplied to `{Key}` command was invalid.";
            else {
                // Attempt to parse the first parameter.
                if (double.TryParse(parameters[0].ToString(), out double a)) {

                    // Attempt to parse the second parameter.
                    if (double.TryParse(parameters[1].ToString(), out double b)) {

                        // Return a message with the sum of a^2 and b^2.
                        return $"The sum of the squares of `{a}` and `{b}` is: {(a * a + b * b)}";
                    } else return $"The second supplied parameter `{parameters[1]}` was invalid.";
                } else return $"The first supplied parameter `{parameters[0]}` was invalid.";
            }
        }

        #endregion

    }
}
