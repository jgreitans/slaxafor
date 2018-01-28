using LuxaforSharp;
using slaxafor.Listener;
using slaxafor.Models;
using slaxafor.Subscriber;

namespace slaxafor_app.Notifier
{
    public class SlackNotifier: ISlackNotifier, ISlackMessageReceiveSubscriber
    {
        private readonly IDevice _luxafor;
        private readonly ISlackListener _slackListener;

        public SlackNotifier(IDevice luxafor, ISlackListener slackListener)
        {
            _luxafor = luxafor;
            _slackListener = slackListener;
            _slackListener.AddSubscriber(this);
        }

        public void OnMessageReceived(SlackMessage message)
        {
            _luxafor.CarryOutPattern(PatternType.RainbowWave, 1);
        }
    }
}