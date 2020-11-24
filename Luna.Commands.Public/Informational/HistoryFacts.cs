using Discord;
using Luna.Core;
using Luna.Core.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Luna.Commands.Public.Informational {
    public sealed class HistoryFacts : LunarCommand {

        #region Constructors

        /// <summary>
        /// Creates a new instance of the hello world command using the key `samples.hello-world`.
        /// </summary>
        /// <remarks>The parameter `inReview` designates whether or not this command is available for public consumption.</remarks>
        public HistoryFacts() : base("today", false) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the core work of the command.
        /// </summary>
        /// <param name="parameters">Any required parameters for this command.</param>
        /// <returns>A message to respond to the user with.</returns>
        protected override string Work(object[] parameters) => $"On this day in history: {GetRandomHistoryFact()}";

        #endregion

        #region Private Methods

        private string GetRandomHistoryFact() {
            Random r = new Random();
            string result = BasicWebServiceHelper.CallWebService("http://history.muffinlabs.com/date");
            Dictionary<string, object> parsedResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(parsedResult["data"].ToString());
            Dictionary<string, object>[] events = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(data["Events"].ToString());
            return events[r.Next(0, events.Length - 1)]["text"].ToString();
        }

        #endregion

    }
}
