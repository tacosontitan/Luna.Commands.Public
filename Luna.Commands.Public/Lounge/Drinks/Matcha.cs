namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class Matcha : DrinkCommand {
        public Matcha() : base("Matcha", "matcha", false) {
            DrinkEmote = "🍵";
            CustomMessage = "Nothing like some green tea to zen out with.";
        }
    }
}
