using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luna.Core;

namespace Luna.Commands.Public.Samples {
    /// <summary>
    /// A simple sum of two squares command used to demonstrate how to setup new commands.
    /// </summary>
    /// <remarks>All commands must be public, and they must derive from `LunarCommand`. We also recommend marking commands as sealed to prevent inheritance.</remarks>
    public sealed class MagicEightBall : LunarCommand {

        #region Fields

        /// <summary>
        /// A collection of answers for our magic eight ball.
        /// </summary>
        private string[] _answers;
        /// <summary>
        /// The random generator for our magic eight ball.
        /// </summary>
        private Random _random;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public MagicEightBall() : base("samples.magic8ball", false) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the initialization code for the command.
        /// </summary>
        /// <remarks>This is the first method called when the command is executed, followed by Work, and then Complete.</remarks>
        protected override void Initialize() {
            base.Initialize();
            _random = new Random();
            _answers = new string[] {
                "It is certain.",
                "It is decidedly so.",
                "Without a doubt.",
                "Yes – definitely.",
                "You may rely on it.",
                "As I see it, yes.",
                "Most likely.",
                "Outlook good.",
                "Yes.",
                "Signs point to yes.",
                "Reply hazy, try again.",
                "Ask again later.",
                "Better not tell you now.",
                "Cannot predict now.",
                "Concentrate and ask again.",
                "Don't count on it.",
                "My reply is no.",
                "My sources say no.",
                "Outlook not so good.",
                "Very doubtful."
            };
        }
        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(LunarUser sender, object[] parameters) {
            // In this sample, the user will ask us a question.
            // We don't really care what the question is.
            // We just need to return a random answer.
            return _answers[_random.Next(0, _answers.Length - 1)];
        }
        /// <summary>
        /// Executes the completion code for the command.
        /// </summary>
        /// <remarks>This method is executed after the Work method and is typically used to dispose of resources, or log information.</remarks>
        protected override void Complete() {
            base.Complete();
            _random = null;
            _answers = null;
        }

        #endregion

    }
}
