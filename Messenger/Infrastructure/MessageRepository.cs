using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Dictionary<Guid, Message> _messageDictionary = new Dictionary<Guid,Message>();

        public void CreateMessage(Message message)
        {
            _messageDictionary[message.MessageId] = message;
        }

        public void UpdateEditedMessage(Guid messageId, Message newMessage)
        {
            _messageDictionary[messageId] = newMessage;
        }

        public void DeleteMessage(Guid messageId)
        {
            _messageDictionary.Remove(messageId);
        }

        public Message GetMessage(Guid messageId)
        {
            if (_messageDictionary.ContainsKey(messageId))
                return _messageDictionary[messageId];
            return null;
        }
    }
}