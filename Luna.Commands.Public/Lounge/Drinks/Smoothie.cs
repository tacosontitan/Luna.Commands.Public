namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class Smoothie : DrinkCommand {
        public Smoothie() : base("Smoothie", "smoothie", false) {
            DrinkEmote = "🥤";
            CustomMessage = "Fresh fruit has you looking SoCal! Time to hit the gym right?";
        }
    }
}
