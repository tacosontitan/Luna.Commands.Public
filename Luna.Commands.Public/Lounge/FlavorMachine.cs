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
    public sealed class FlavorMachine : LunarCommand {

        #region Flavors

        /// <summary>
        /// A collection of valid drink flavors in the lunar lounge.
        /// </summary>
        public static string[] Flavors => new string[] {
            "Acerola", "Apple", "Apricot", "Avocado",
            "Banana", "Blackberry", "Blackcurrant", "Blueberry", "Breadfruit",
            "Cantaloupe", "Carambola", "Cherimoya", "Cherries", "Clementine", "Coconut", "Cranberry",
            "Date", "Dragonfruit", "Durian",
            "Elderberry",
            "Feijoa", "Figs",
            "Gooseberry", "Grapefruit", "Grapes", "Guava",
            "Honeydew",
            "Jackfruit", "Java", "Jujube",
            "Kiwi", "Kumquat",
            "Lemon", "Lime", "Longan", "Loquat", "Lychee",
            "Mandarin", "Mango", "Mangosteen", "Mulberry",
            "Nectarine",
            "Olives", "Orange",
            "Papaya", "Passion", "Peaches", "Pear", "Persimmon", "Pineapple", "Pitanga",
            "Plantain", "Plums", "Pomegranate", "Prickly Pear", "Prunes", "Pummelo",
            "Quince",
            "Raspberry", "Rhubarb", "Rose",
            "Sapodilla", "Sapote", "Soursop", "Strawberry",
            "Tamarind", "Tangerine",
            "Watermelon"
        };

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public FlavorMachine() : base("flavormachine", false) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(object[] parameters) => RandomHelper.GetRandomValue(Flavors);

        #endregion

    }
}
