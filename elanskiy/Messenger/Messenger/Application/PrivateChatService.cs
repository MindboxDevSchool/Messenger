using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public class PrivateChatService : IPrivateChatService
    {
        private readonly IPrivateChatManager _privateChatManager;

        public PrivateChatService(IPrivateChatManager privateChatManager)
        {
            _privateChatManager = privateChatManager;
        }

        public Guid CreatePrivateChat(Guid from, Guid to)
        {
            return _privateChatManager.CreatePrivateChat(from, to);
        }
        
        public Guid CreateMessage(Guid from, Guid to, string text)
        {
            return _privateChatManager.CreateMessage(from, to, text);
        }

        public IPrivateChat GetChat(Guid userId, Guid chatId)
        {
            return _privateChatManager.GetChat(userId, chatId);
        }

        public void RemoveChat(Guid userId, Guid chatId)
        {
            _privateChatManager.RemoveChat(userId, chatId);
        }

        public void EditMessage(Guid userId, Guid chatId, Guid messageId, string text)
        {
            _privateChatManager.EditMessage(userId, chatId, messageId, text);
        }

        public void RemoveMessage(Guid userId, Guid chatId, Guid messageId)
        {
            _privateChatManager.RemoveMessage(userId, chatId, messageId);
        }
    }
}