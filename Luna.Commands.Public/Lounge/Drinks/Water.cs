namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class Water : DrinkCommand {
        public Water() : base("Water", "water", false) {
            DrinkEmote = "🌊";
            CustomMessage = "Straight from the tap, noice!";
        }
    }
}
