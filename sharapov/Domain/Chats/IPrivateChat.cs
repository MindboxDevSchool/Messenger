namespace Messenger.Domain.Chats
{
    public interface IPrivateChat
    {
        OperationStatus AddMessage(Chatter chatter, string textMessage);
    }
}