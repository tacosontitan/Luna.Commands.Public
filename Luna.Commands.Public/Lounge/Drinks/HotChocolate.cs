namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class HotChocolate : DrinkCommand {
        public HotChocolate() : base("Hot Chocolate", "hotchocolate", false) {
            DrinkEmote = "☕";
            CustomMessage = "It's sweet and of course, chocolatey. Wait... Is that mint?";
        }
    }
}
