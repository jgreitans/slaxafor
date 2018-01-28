using slaxafor.Client;
using slaxafor.Models;
using slaxafor.Subscriber;

namespace slaxafor.Listener
{
    public class SlackListener: ISlackListener
    {
        private ISlackMessageReceiveSubscriber _subscriber;

        public SlackListener(ISlackClient slackClient)
        {
            slackClient.OnMessageReceived = NotifySubscribers;
        }

        public void AddSubscriber(ISlackMessageReceiveSubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        private void NotifySubscribers(SlackMessage message)
        {
            _subscriber.OnMessageReceived(message);
        }
    }
}