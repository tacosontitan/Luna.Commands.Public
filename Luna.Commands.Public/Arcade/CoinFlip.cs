using Luna.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Commands.Public.Games {
    /// <summary>
    /// A simple coin flip game.
    /// </summary>
    public sealed class CoinFlip : LunarCommand {

        #region Fields

        private int _tossCount;
        private Random _random;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public CoinFlip() : base("flip", false) {
            _tossCount = 0;
            _random = new Random();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(object[] parameters) {
            int result = _random.Next(1, 12000);
            if (result <= 5999)
                return "Heads.";
            else if (result <= 11998)
                return "Tails.";
            else
                return "It's a draw!";
        }

        #endregion

    }
}
