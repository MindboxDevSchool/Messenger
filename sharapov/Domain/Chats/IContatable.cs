namespace Messenger.Domain.Chats
{
    public interface IContatable
    {
        public OperationStatus AddMessage(IChatRole role, string textMessage);
        public OperationStatus DeleteMessage(IChatRole role, int messageId);
        public OperationStatus EditMessage(IChatRole role, int messageId, string textForReplace);
    }
}