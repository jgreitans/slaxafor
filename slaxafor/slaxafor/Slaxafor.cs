using slaxafor.Client;
using slaxafor.Client.Auth;
using slaxafor.Credentials;
using slaxafor.Listener;
using SlackAPI;
using Unity;
using Unity.Resolution;

namespace slaxafor
{
    public static class Slaxafor
    {
        private static readonly IUnityContainer _container;

        static Slaxafor()
        {
            _container = new UnityContainer();
            ConfigureContainer(_container);
        }

        private static void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<ISlackListener, SlackListener>();
            container.RegisterType<ISlackClient, SlaxaforSlackClient>();
            container.RegisterType<IOauthAuthenticator, OauthAuthenticator>();
        }

        public static ISlackListener GetSlackListener(string team, AppCredentialModel appCredentials)
        {
            var authenticator = _container.Resolve<IOauthAuthenticator>();

            var slackSocketClient =
                _container.Resolve<SlackSocketClient>(new ParameterOverride("token",
                    authenticator.Authenticate(team, appCredentials)));
            
            var client = _container.Resolve<ISlackClient>(new ParameterOverride("client", slackSocketClient));

            return _container.Resolve<ISlackListener>(new ParameterOverride("client", client));
        }
    }
}