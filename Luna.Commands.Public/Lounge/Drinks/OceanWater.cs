namespace Luna.Commands.Public.Lounge.Drinks {
    public sealed class OceanWater : DrinkCommand {
        public OceanWater() : base("Ocean Water", "oceanwater", false) {
            DrinkEmote = "🌊";
            CustomMessage = "Fish pee in that... All day.";
        }
    }
}
