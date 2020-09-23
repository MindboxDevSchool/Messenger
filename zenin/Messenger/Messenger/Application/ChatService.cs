using System;
using System.Collections.Generic;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public class ChatService : IChatService
    {
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        public void CreateChat(IChat chat)
        {
            _chatRepository.CreateChat(chat);
        }

        public void DeleteChat(IChat chat)
        {
            _chatRepository.DeleteChat(chat.Id);
        }

        private readonly IChatRepository _chatRepository;
    }
}