namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class Latte : DrinkCommand {
        public Latte() : base("Latte", "latte", false) {
            DrinkEmote = "☕";
            CustomMessage = "Extra brown sugar?";
        }
    }
}
