namespace Messenger.Domain.Chats
{
    public interface ISubscription
    {
        void AddChatter(IChatter subscriber);
        void RemoveChatter(IChatter subscriber);
    }
}