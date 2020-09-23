namespace Messenger.Domain
{
    public interface ISubscriber
    {
        void Update(Message message);
    }
}