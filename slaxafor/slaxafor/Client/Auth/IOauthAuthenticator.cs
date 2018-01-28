using slaxafor.Credentials;

namespace slaxafor.Client.Auth
{
    public interface IOauthAuthenticator
    {
        string Authenticate(string team, AppCredentialModel appCredentials);
    }
}