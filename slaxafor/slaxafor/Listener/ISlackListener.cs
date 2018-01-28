using slaxafor.Subscriber;

namespace slaxafor.Listener
{
    public interface ISlackListener
    {
        void AddSubscriber(ISlackMessageReceiveSubscriber subscriber);
    }
}