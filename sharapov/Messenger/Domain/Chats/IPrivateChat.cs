namespace Messenger.Domain.Chats
{
    public interface IPrivateChat
    {
        OperationStatus AddMessage(IChatter fromChatter, string addingMessage);
        OperationStatus DeleteMessage(IChatter chatter, int messageId);
        OperationStatus EditMessage(IChatter chatter, int messageId, string textMessage);
    }
}