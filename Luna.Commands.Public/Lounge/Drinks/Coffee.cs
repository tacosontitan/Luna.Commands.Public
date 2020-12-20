namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class Coffee : DrinkCommand {
        public Coffee() : base("Coffee", "coffee", false) {
            DrinkEmote = "☕";
            CustomMessage = "Piping hot and gently stirred.";
        }
    }
}
