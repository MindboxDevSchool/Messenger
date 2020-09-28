using Messenger.Domain;
using Messenger.Domain.Chats;

namespace Usage
{
    public class PrivateChatFactory : IPrivateChatFactory
    {
        public PrivateChat Create(IChatter firstChatter, IChatter secondChatter, IMessagesRepository repositoryUserMessages,
            IMessageIdGenerator messageIdGenerator, int privateChatId)
        {
            return new PrivateChat(firstChatter, secondChatter, repositoryUserMessages, messageIdGenerator,  privateChatId);
        }
    }
}