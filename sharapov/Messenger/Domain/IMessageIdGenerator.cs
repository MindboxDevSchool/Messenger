namespace Messenger.Domain
{
    public interface IMessageIdGenerator
    {
        int GetNextMessageId();
    }
}