using System;
using System.Threading;
using slaxafor.Client.Auth;
using slaxafor.Models;
using SlackAPI;
using SlackAPI.WebSocketMessages;

namespace slaxafor.Client
{
    public class SlaxaforSlackClient: ISlackClient
    {
        private readonly SlackSocketClient _client;

        public SlaxaforSlackClient(SlackSocketClient client)
        {
            _client = client;
        }

        public Action<SlackMessage> OnMessageReceived { get; set; }

        public void Connect()
        {
            var clientReady = new ManualResetEventSlim(false);
            _client.Connect(response => { clientReady.Set(); });
            clientReady.Wait();
            _client.OnMessageReceived += NotifySubscribers;
        }

        private void NotifySubscribers(NewMessage message)
        {
            OnMessageReceived?.Invoke(new SlackMessage
            {
                Channel = message.channel,
                User = message.user,
                Message = message.text,
                Timestamp = message.ts
            });
        }

    }
}