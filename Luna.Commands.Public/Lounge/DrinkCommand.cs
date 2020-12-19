using Luna.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luna.Commands.Public.Lounge {
    /// <summary>
    /// A simple hello world command used to demonstrate how to setup new commands.
    /// </summary>
    /// <remarks>All commands must be public, and they must derive from `LunarCommand`. We also recommend marking commands as sealed to prevent inheritance.</remarks>
    public abstract class DrinkCommand : LunarCommand {

        #region Fields

        private string[] _modifiers = {
            "a refreshing",
            "an invigorating",
            "a revitalizing",
            "a reviving",
            "a restoring",
            "a bracing",
            "a fortifying",
            "an enlivening",
            "a stimulating",
            "a freshening",
            "an energizing",
            "an exhilarating",
            "a reanimating"
        };

        #endregion

        #region Properties

        public string DisplayName { get; private set; }
        protected string DrinkEmote { get; set; } = "🥤";
        protected string CustomMessage { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public DrinkCommand(string displayName, string key, bool inReview = true) : base(key, inReview) => DisplayName = displayName;

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(object[] parameters) {
            List<string> validFlavors = new List<string>();
            if (parameters != null)
                foreach (var param in parameters)
                    if (FlavorMachine.Flavors.Any(a => a.Equals(param.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                        validFlavors.Add(param.ToString());

            if (validFlavors.Count < 1)
                validFlavors.Add(RandomHelper.GetRandomValue(FlavorMachine.Flavors));

            string flavorDescription = string.Join(", ", validFlavors);
            flavorDescription = flavorDescription.Insert(flavorDescription.LastIndexOf(", "), "<FINAL_INDEX>");
            flavorDescription = flavorDescription.Replace("<FINAL_INDEX>", " and ");

            if (string.IsNullOrWhiteSpace(flavorDescription))
                return $"{Prefabs.UserMentionPlaceholder}, here's {RandomHelper.GetRandomValue(_modifiers)} {flavorDescription} {DisplayName} for you! {DrinkEmote} {CustomMessage}".Trim();

            return "We don't serve the flavor you requested. If you need a list of available flavors you can request it with the `!lounge.flavors` command.";
        }

        #endregion

    }
}
