using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class MessageRepository : IMessageRepository
    {
        public void CreateMessage(Message message)
        {
            _messageDictionary[message.Id] = message;
        }

        public Message GetMessage(Guid messageId)
        {
            if(_messageDictionary.ContainsKey(messageId))
                return _messageDictionary[messageId];
            return null;
        }

        public void UpdateMessage(Guid messageId, Message newMessage)
        {
            _messageDictionary[messageId] = newMessage;
        }

        public void DeleteMessage(Guid messageId)
        {
            _messageDictionary.Remove(messageId);
        }
        
        private readonly Dictionary<Guid, Message> _messageDictionary = new Dictionary<Guid, Message>();
    }
}