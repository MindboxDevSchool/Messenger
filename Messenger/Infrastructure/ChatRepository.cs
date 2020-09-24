using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class ChatRepository : IChatRepository
    {
        private readonly Dictionary<Guid, IChat> _chatDictionary = new Dictionary<Guid, IChat>();

        public void CreateChat(IChat chat)
        {
            _chatDictionary[chat.ChatId] = chat;
        }

        public void DeleteChat(Guid chatId)
        {
            _chatDictionary.Remove(chatId);
        }

        public IChat GetChat(Guid chatId)
        {
            if (_chatDictionary.ContainsKey(chatId))
                return _chatDictionary[chatId];
            return null;
        }
    }
}