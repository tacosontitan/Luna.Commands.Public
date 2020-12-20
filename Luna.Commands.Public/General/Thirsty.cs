using Discord;
using Luna.Core;
using Luna.Core.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Luna.Commands.Public.Informational {
    public sealed class Thirsty : LunarCommand {

        #region Constructors

        public Thirsty() : base("thirsty", false) { }

        #endregion

        #region Protected Methods

        protected override string Work(LunarUser sender, object[] parameters) {
            Dictionary<string, object> drinkData = GetRandomDrink();
            return $"You should drink a {drinkData["strDrink"]}.";
        }
        protected override Embed WorkEmbed(LunarUser sender, object[] parameters) {
            Dictionary<string, object> drinkData = GetRandomDrink();

            List<string> ingredients = new List<string>();
            for (int i = 1; i < 15; i++) {
                string measurement = drinkData[$"strMeasure{i}"]?.ToString();
                string ingredient = drinkData[$"strIngredient{i}"]?.ToString();
                string result = $"{(string.IsNullOrWhiteSpace(measurement) ? string.Empty : measurement)} {(string.IsNullOrWhiteSpace(ingredient) ? string.Empty : ingredient)}";
                if (!string.IsNullOrWhiteSpace(result))
                    ingredients.Add(result);
            }

            EmbedAuthorBuilder authorBuilder = new EmbedAuthorBuilder();
            authorBuilder.Name = "The Cocktail DB";
            authorBuilder.Url = "https://www.thecocktaildb.com/api.php";

            EmbedFooterBuilder footerBuilder = new EmbedFooterBuilder();
            footerBuilder.Text = drinkData["strAlcoholic"].ToString();

            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.ThumbnailUrl = drinkData["strDrinkThumb"].ToString();
            embedBuilder.ImageUrl = "https://www.thecocktaildb.com/images/logo.png";
            embedBuilder.Author = authorBuilder;
            embedBuilder.Footer = footerBuilder;
            embedBuilder.Color = Color.Purple;
            embedBuilder.Description = $@"{drinkData["strDrink"]}
**Ingredients**:
```{string.Join(Environment.NewLine, ingredients.ToArray())}```
**Instructions**:
{drinkData["strInstructions"]}";

            return embedBuilder.Build();
        }

        #endregion

        #region Private Methods

        private Dictionary<string, object> GetRandomDrink() {
            string result = BasicWebServiceHelper.CallWebService("https://www.thecocktaildb.com/api/json/v1/1/random.php");
            Dictionary<string, object> parsedResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            Dictionary<string, object>[] data = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(parsedResult["drinks"].ToString());
            return data[0];
        }

        #endregion

    }
}