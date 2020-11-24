using Discord;
using Luna.Core;
using Luna.Core.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Commands.Public.Health {
    /// <summary>
    /// Get the latest COVID-19 statistics.
    /// </summary>
    public sealed class CovidStatistics : LunarCommand {

        #region Constructors

        public CovidStatistics() : base("covid", true) { }

        #endregion

        #region Protected Methods

        protected override string Work(object[] parameters) {
            Dictionary<string, double> globalStats = GetCovidSummary();
            return $@"There are {globalStats["NewConfirmed"].ToString("N")} new cases out of {globalStats["TotalConfirmed"].ToString("N")} total. There are {globalStats["NewDeaths"].ToString("N")} new cases out of {globalStats["TotalDeaths"].ToString("N")} total. There are {globalStats["NewRecovered"].ToString("N")} new cases out of {globalStats["TotalRecovered"].ToString("N")} total. - Data sourced from COVID-19 API.";
        }
        protected override Embed WorkEmbed(object[] parameters) {
            Dictionary<string, double> globalStats = GetCovidSummary();
            EmbedAuthorBuilder authorBuilder = new EmbedAuthorBuilder();
            authorBuilder.Name = "Global COVID-19 Statistics";
            authorBuilder.Url = "https://covid19api.com/";

            EmbedFooterBuilder footerBuilder = new EmbedFooterBuilder();
            footerBuilder.Text = "Data sourced from COVID-19 API.";

            List<EmbedFieldBuilder> fields = new List<EmbedFieldBuilder>();
            fields.Add(new EmbedFieldBuilder() {
                Name = "Cases",
                Value = $"There are **{globalStats["NewConfirmed"]:N0}** new of **{globalStats["TotalConfirmed"]:N0}** total."
            });
            fields.Add(new EmbedFieldBuilder() {
                Name = "Deaths",
                Value = $"There are **{globalStats["NewDeaths"]:N0}** new of **{globalStats["TotalDeaths"]:N0}** total."
            });
            fields.Add(new EmbedFieldBuilder() {
                Name = "Recoveries",
                Value = $"There are **{globalStats["NewRecovered"]:N0}** new of **{globalStats["TotalRecovered"]:N0}** total."
            });

            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.Color = Color.Red;
            embedBuilder.ThumbnailUrl = "https://styles.redditmedia.com/t5_2f4l19/styles/communityIcon_s9svsk6xmcg41.jpg?width=256&format=pjpg&s=bcbf2d8ea8657792d0ebe9eed38ce729d874d5b5";
            embedBuilder.Timestamp = DateTime.UtcNow;
            embedBuilder.Author = authorBuilder;
            embedBuilder.Fields = fields;
            embedBuilder.Footer = footerBuilder;
            return embedBuilder.Build(); ;
        }

        #endregion

        #region Private Methods

        private Dictionary<string, double> GetCovidSummary() {
            string result = BasicWebServiceHelper.CallWebService("https://api.covid19api.com/summary");
            Dictionary<string, object> parsedResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            Dictionary<string, double> data = JsonConvert.DeserializeObject<Dictionary<string, double>>(parsedResult["Global"].ToString());
            return data;
        }

        #endregion

    }
}
