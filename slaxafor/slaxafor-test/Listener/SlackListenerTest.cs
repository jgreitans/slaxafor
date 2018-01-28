using Moq;
using slaxafor.Client;
using slaxafor.Listener;
using slaxafor.Models;
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

        [Fact]
        public void SubscriberAdded_MessageReceived_SubscriberIsNotified()
        {
            var slackClientMock = new Mock<ISlackClient>();
            var listener = new SlackListener(slackClientMock.Object);
            var subscriberMock = new Mock<ISlackMessageReceiveSubscriber>();
            subscriberMock.Setup(m => m.OnMessageReceived(It.IsAny<SlackMessage>())).Verifiable();
            listener.AddSubscriber(subscriberMock.Object);

            listener.OnMessageReceived(new SlackMessage());
            
            subscriberMock.Verify(m => m.OnMessageReceived(It.IsAny<SlackMessage>()), Times.Once);
        }
    }
}