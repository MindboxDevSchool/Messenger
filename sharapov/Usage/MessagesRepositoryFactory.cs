using Messenger.Infrastructure;

namespace Usage
{
    class MessagesRepositoryFactory : IMessagesRepositoryFactory
    {
        public MessagesRepository Create()
        {
            return new MessagesRepository();
        }
    }
}