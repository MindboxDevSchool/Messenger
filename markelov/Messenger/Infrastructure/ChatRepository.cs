using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class ChatRepository : IChatRepository
    {
        private readonly Dictionary<Guid, IChat> _chatRepository = new Dictionary<Guid, IChat>();
        public IChat GetChat(Guid chatId)
        {
            if (!_chatRepository.TryGetValue(chatId, out var chat))
            {
                throw new Exception($"Chat with Id {chatId} is not found!");
            }
            return chat;
        }

        public void SaveChat(IChat chat)
        {
            _chatRepository[chat.Id] = chat;
        }

        public void DeleteChat(Guid chatId)
        {
            _chatRepository.Remove(chatId);
        }
    }
}