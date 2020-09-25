using System;
using System.Collections.Generic;
using System.IO;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public class PrivateChatService : ChatService
    {
        private IChatRepository _chatRepository;
        
        public PrivateChatService(IChatRepository chatRepository) : base(chatRepository)
        {
            _chatRepository = chatRepository;
        }
        
        
        public override IChat CreateChat(ChatType chatType, List<User> firstChatUsers, String chatName)
        {
            if (firstChatUsers.Count == 2)
            {
                IChat privateChat = new PrivateChat(firstChatUsers[0], 
                    firstChatUsers[1],
                    chatName);
                
                _chatRepository.AddChat(privateChat);
                return privateChat;
            }
            
            throw new InvalidDataException("The private chat has to be created with two users!");
        }
    }
}