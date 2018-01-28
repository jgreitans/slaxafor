using slaxafor.Models;

namespace slaxafor.Subscriber
{
    public interface ISlackMessageReceiveSubscriber
    {
        void OnMessageReceived(SlackMessage message);
    }
}