using Messenger.Infrastructure;

namespace Usage
{
    public interface IMessagesRepositoryFactory
    {
        MessagesRepository Create();
    }
}