namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class Tea : DrinkCommand {
        public Tea() : base("Tea", "tea", false) {
            DrinkEmote = "🍵";
            CustomMessage = "Nothing wrong with the basics!";
        }
    }
}
