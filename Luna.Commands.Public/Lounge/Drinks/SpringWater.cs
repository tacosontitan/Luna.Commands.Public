namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class SpringWater : DrinkCommand {
        public SpringWater() : base("Spring Water", "springwater", false) {
            DrinkEmote = "🌊";
            CustomMessage = "I heard it's from Fiji!";
        }
    }
}
