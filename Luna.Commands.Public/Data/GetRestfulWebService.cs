using Luna.Core;
using Luna.Core.Web;
using System;

namespace Luna.Commands.Public.Data {
    public sealed class GetRestfulWebService : LunarCommand {

        #region Constructors

        public GetRestfulWebService() : base("get", true) { }

        #endregion

        #region Protected Methods

        protected override string Work(object[] parameters) {
            if (parameters.Length > 0) {
                string response = BasicWebServiceHelper.CallWebService(parameters[0].ToString());
                return response.Substring(0, Math.Min(500, response.Length));
            }
            return null;
        }

        #endregion

    }
}
