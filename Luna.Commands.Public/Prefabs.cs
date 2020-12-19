namespace Luna.Commands.Public {
    public sealed class Prefabs {
        /// <summary>
        /// Luna's placeholder for user mentions: [<@USERMENTION@>]
        /// </summary>
        public const string UserMentionPlaceholder = @"[<@USERMENTION@>]";
        /// <summary>
        /// The standard error message to return from the Work method of a command not supported outside of Discord.
        /// </summary>
        public const string NotSupportedOutsideOfDiscord = @"This command is not supported outside of Discord.";

    }
}
