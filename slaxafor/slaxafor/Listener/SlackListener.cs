using slaxafor.Client;
using slaxafor.Models;
using slaxafor.Subscriber;

namespace slaxafor.Listener
{
    public class SlackListener
    {
        private ISlackMessageReceiveSubscriber _subscriber;

        public SlackListener(ISlackClient slackClient)
        {
            
        }

        public void AddSubscriber(ISlackMessageReceiveSubscriber subscriber)
        {
            _subscriber = subscriber;
        }


        public void OnMessageReceived(SlackMessage message)
        {
            _subscriber.OnMessageReceived(message);
        }
    }
}