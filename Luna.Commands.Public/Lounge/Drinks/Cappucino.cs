namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class Cappucino : DrinkCommand {
        public Cappucino() : base("Cappucino", "cappucino", false) {
            DrinkEmote = "☕";
            CustomMessage = "It's better than Starbucks.";
        }
    }
}
