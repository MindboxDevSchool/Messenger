using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class ChatRepository : IChatRepository
    {
        public void CreateChat(IChat chat)
        {
            _chatDictionary[chat.Id] = chat;
        }

        public IChat GetChat(Guid chatId)
        {
            if (_chatDictionary.ContainsKey(chatId))
                return _chatDictionary[chatId];
            return null;
        }

        public void DeleteChat(Guid chatId)
        {
            _chatDictionary.Remove(chatId);
        }
        
        private readonly Dictionary<Guid, IChat> _chatDictionary = new Dictionary<Guid, IChat>();
    }
}