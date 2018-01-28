using slaxafor.Credentials;

namespace slaxafor.Client.Auth
{
    public class OauthAuthenticator: IOauthAuthenticator
    {
        public string Authenticate(string team, AppCredentialModel appCredentials)
        {
            throw new System.NotImplementedException();
        }
        
        /*
        public void Authenticate()
        {
            var state = Guid.NewGuid().ToString();
            var redirectUri = "";
            var uri = SlackClient.GetAuthorizeUri(_clientId, SlackScope.Identify | SlackScope.Read, redirectUri, state, _team);
            var process = Process.Start(uri.ToString());
            if (process == null)
            {
                throw new AuthenticationException();
            }
        }
        */
    }
}