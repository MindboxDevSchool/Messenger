using System;
using System.Collections.Generic;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public  abstract class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        // создать где-то объект chat со всеми параметрами и сюда передать
        public abstract IChat CreateChat(ChatType chatType, List<User> firstChatUsers);

        public void GetChat(IChat chat)
        {
            _chatRepository.GetChat(chat.ChatId);
        }

        public void DeleteChat(IChat chat)
        {
            _chatRepository.DeleteChat(chat.ChatId);
        }

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
    }
}