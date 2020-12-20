using Discord;
using Luna.Core;
using Luna.Core.Web;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Luna.Commands.Public.Imagery {
    /// <summary>
    /// Performs a simple GIF search using Giphy's public API.
    /// </summary>
    public sealed class GifSearch : LunarCommand {

        #region Constructors

        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public GifSearch() : base("gif", false) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(LunarUser sender, object[] parameters) => Prefabs.NotSupportedOutsideOfDiscord;
        /// <summary>
        /// Executes the core work of the command and builds an embed object for Discord to consume.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>An embed object for Discord consumption.</returns>
        protected override Embed WorkEmbed(LunarUser sender, object[] parameters) {
            try {
                if (parameters.Length > 0) {
                    string searchTerm = parameters[0].ToString();
                    string result = BasicWebServiceHelper.CallWebService($"https://api.giphy.com/v1/gifs/random?api_key=FSTxSjTCxxNkbiGenZrBpTzq6S3p2Y3q&tag={searchTerm}&rating=r");
                    Dictionary<string, Dictionary<string, object>> data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(result);
                    EmbedBuilder embedBuilder = new EmbedBuilder();
                    embedBuilder.ImageUrl = data["data"]["image_original_url"].ToString();
                    embedBuilder.Description = "Here's that GIF you requested!";
                    embedBuilder.Color = Color.Purple;
                    return embedBuilder.Build();
                }
            } catch { }
            return null;
        }

        #endregion

    }
}
