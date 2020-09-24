using System;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        

        // создать где-то объект chat со всеми параметрами и сюда передать
        public Chat CreateChat(User chatCreator, String chatType)
        {
            switch (chatType)
            {
                case "ChannelChat":
                    Chat chat = new ChannelChat(chatCreator);
                    break;
                case "GroupChat":
                    Chat chat = new GroupChat(chatCreator);
                    break;
                case "PrivateChat":
                    Chat chat = new PrivateChat(chatCreator);
                    break;
                // abstrat?
                    
            }
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