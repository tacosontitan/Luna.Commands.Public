namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class BubbleTea : DrinkCommand {
        public BubbleTea() : base("Bubble Tea", "bubbletea", false) {
            DrinkEmote = "🥤";
            CustomMessage = "Those black bubbles and fresh fruit slices look delicious!";
        }
    }
}
