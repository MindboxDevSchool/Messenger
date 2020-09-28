namespace Messenger.Domain.Chats
{
    public interface IGroup
    {
        public OperationStatus AddMessage(IChatter chatter, string textMessage);
        public OperationStatus DeleteMessage(IChatter chatter, int messageId);
        public OperationStatus EditMessage(IChatter chatter, int messageId, string textForReplace);
    }
}