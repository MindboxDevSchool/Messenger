using Messenger.Domain;
using Messenger.Domain.Chats;

namespace Usage
{
    public interface IPrivateChatFactory
    {
        public PrivateChat Create(IChatter firstChatter, IChatter secondChatter, IMessagesRepository repositoryUserMessages,
            IMessageIdGenerator messageIdGenerator, int privateChatId);
    }
}