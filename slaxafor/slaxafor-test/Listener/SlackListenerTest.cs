using Moq;
using slaxafor.Client;
using slaxafor.Listener;
using slaxafor.Subscriber;
using Xunit;

namespace slaxafor_test.Listener
{
    public class SlackListenerTest
    {
        [Fact]
        public void ListenerExists()
        {
            var slackClientMock = new Mock<ISlackClient>();
            var listener = new SlackListener(slackClientMock.Object);
        }

        [Fact]
        public void CanAddSubscriber()
        {
            var slackClientMock = new Mock<ISlackClient>();
            var listener = new SlackListener(slackClientMock.Object);
            var subscriber = new Mock<ISlackMessageReceiveSubscriber>();
            listener.AddSubscriber(subscriber.Object);
        }

    }
}