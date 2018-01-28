using System;
using slaxafor.Models;

namespace slaxafor.Client
{
    public interface ISlackClient
    {
        Action<SlackMessage> OnMessageReceived { get; set; }
        void Connect();
    }
}