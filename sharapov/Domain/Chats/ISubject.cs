namespace Messenger.Domain.Chats
{
    public interface ISubject
    {
        void AddChatter(Chatter subscriber);
        void RemoveChatter(Chatter subscriber);
        void Notify(Message message);
    }
}