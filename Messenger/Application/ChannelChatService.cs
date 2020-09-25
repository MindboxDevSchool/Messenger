using System.Collections.Generic;
using System.IO;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public class ChannelChatService : ChatService
    {
        private IChatRepository _chatRepository;
        
        public ChannelChatService(IChatRepository chatRepository) : base(chatRepository)
        {
            _chatRepository = chatRepository;
        }
        
        
        public override IChat CreateChat(ChatType chatType, List<User> firstChatUsers)
        {
            if (firstChatUsers.Count == 1)
            {
                IChat channelChat = new ChannelChat(firstChatUsers[0]);
                
                _chatRepository.AddChat(channelChat);
                return channelChat;
            }
            
            throw new InvalidDataException("The channel can only have one creator!");
        }
    }
}