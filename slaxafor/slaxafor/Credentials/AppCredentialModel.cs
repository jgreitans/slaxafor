using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace slaxafor.Credentials
{
    public class AppCredentialModel
    {
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }

        public static AppCredentialModel Load(string appSecretFile)
        {
            var obj = JObject.Load(new JsonTextReader(new StreamReader(appSecretFile)));
            var result = new AppCredentialModel
            {
                ClientId = obj["clientId"].Value<string>(),
                ClientSecret = obj["clientSecret"].Value<string>()
            };
            return result;
        }
    }
}
