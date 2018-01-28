using slaxafor.Models;
using Xunit;

namespace slaxafor_test.Models
{
    public class SlackNotificationTest
    {
        [Fact]
        public void SlackNotification_ContainsMessage()
        {
            var notification = new SlackNotification();
            Assert.NotNull(notification);
            Assert.Null(notification.Message);
        }
    }
}