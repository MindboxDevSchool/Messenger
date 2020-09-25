using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class PrivateChatRepository : IPrivateChatRepository
    {
        private Dictionary<Guid,Message> _privateMessages = new Dictionary<Guid, Message>();
        private Dictionary<Guid,PrivateChat> _privateChats = new Dictionary<Guid, PrivateChat>();
        
        public void SaveChat(PrivateChat chat)
        {
            _privateChats[chat.Id] = chat;
        }

        public void SaveMessage(Message message)
        {
            _privateMessages[message.Id] = message;
        }

        public PrivateChat GetChat(Guid entityId)
        {
            return _privateChats[entityId];
        }

        public void RemoveChat(Guid entityId)
        {
            _privateChats.Remove(entityId);
        }

        public void EditMessage(Message editedMessage)
        {
            _privateMessages[editedMessage.Id] = editedMessage;
        }

        public void RemoveMessage(Guid chatId, Guid messageId)
        {
            _privateMessages.Remove(messageId);
        }

        public Message GetMessage(Guid messageId)
        {
            return _privateMessages[messageId];
        }
    }
}