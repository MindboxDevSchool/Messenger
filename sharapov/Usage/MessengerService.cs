using System.Collections.Generic;
using Messenger.Domain;
using Messenger.Domain.Chats;

namespace Usage
{
    class MessengerService : IMessengerService //facade
    {
        private readonly IChatterFactory _chatterFactory;
        private readonly IPrivateChatFactory _privateChatFactory;
        private readonly IGroupChatFactory _groupChatFactory;
        private readonly IChannelFactory _channelFactory;
        
        private readonly IMessagesRepositoryFactory _messagesRepositoryFactory; 
        
        public MessengerService(
            IChatterFactory chatterFactory, 
            IPrivateChatFactory privateChatFactory,
            IGroupChatFactory groupChatFactory, 
            IChannelFactory channelFactory, 
            IMessagesRepositoryFactory messagesRepositoryFactory)
        {
            _chatterFactory = chatterFactory;
            _privateChatFactory = privateChatFactory;
            _groupChatFactory = groupChatFactory;
            _channelFactory = channelFactory;
            _messagesRepositoryFactory = messagesRepositoryFactory;
        }
        
        public IReadOnlyCollection<Message> User1SendUser2AndPullFromRepo(string textForSending,
            int amountMessageForPull) {
            var user1 = _chatterFactory.Create("user1", 1); 
            var user2 = _chatterFactory.Create("user2", 2);
            var messagesRepository = _messagesRepositoryFactory.Create();
            var messageIdGenerator = new MessageIdGenerator(1);
            const int chatId = 1;
            var privateChat = _privateChatFactory.Create(user1, user2, messagesRepository, messageIdGenerator, chatId);
            privateChat.AddMessage(user1, textForSending);
            return messagesRepository.PullMessageForClient(privateChat.PrivateChatId, amountMessageForPull);
        }
    }
}