using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Dictionary<Guid, IMessage> _messageDictionary = new Dictionary<Guid,IMessage>();

        public IMessage CreateMessage(IUser user, String messageText)
        {
            IMessage message = new Message(user, messageText);
            _messageDictionary[message.MessageId] = message;
            return message;
        }

        public void UpdateEditedMessage(Guid messageId, IMessage newMessage)
        {
            _messageDictionary[messageId] = newMessage;
        }

        public void DeleteMessage(Guid messageId)
        {
            _messageDictionary.Remove(messageId);
        }

        public IMessage GetMessage(Guid messageId)
        {
            if (_messageDictionary.ContainsKey(messageId))
                return _messageDictionary[messageId];
            return null;
        }
    }
}