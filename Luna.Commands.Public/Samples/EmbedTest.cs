using Discord;
using Luna.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Commands.Public.Samples {
    public sealed class EmbedTest : LunarCommand {

        #region Fields

        private string _responseMessage = @"This is a simple test of the embed system for commands. In order to build commands that send back embeds to Discord, simply use the `ExecuteEmbed` method provided on the `LunarCommand` object.";

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public EmbedTest() : base("samples.embed", false) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(LunarUser sender, object[] parameters) => _responseMessage;
        /// <summary>
        /// Executes the core work of the command and builds an embed object for Discord to consume.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>An embed object for Discord consumption.</returns>
        protected override Embed WorkEmbed(LunarUser sender, object[] parameters) {
            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.Description = _responseMessage;
            embedBuilder.Color = Color.Purple;
            embedBuilder.ThumbnailUrl = "https://assets.codepen.io/2940219/Code+Brackets+and+Moon+%28Transparent%29.png";
            return embedBuilder.Build();
        }

        #endregion

    }
}
