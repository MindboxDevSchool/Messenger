using System;
using System.Collections.Generic;
using System.IO;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public class GroupChatService : ChatService
    {
        private IChatRepository _chatRepository;
        
        public GroupChatService(IChatRepository chatRepository) : base(chatRepository)
        {
            _chatRepository = chatRepository;
        }
        
        
        public override IChat CreateChat(ChatType chatType, List<User> firstChatUsers, String chatName)
        {
            if (firstChatUsers.Count == 1)
            {
                IChat groupChat = new GroupChat(firstChatUsers[0], chatName);
                
                _chatRepository.AddChat(groupChat);
                return groupChat;
            }
            
            throw new InvalidDataException("The group has to be created by the only one user!");
        }
    }
}