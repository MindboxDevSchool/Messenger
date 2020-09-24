using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger
{
    public class MessageInGroupRepository:IMessageInGroupRepository
    {
        public void CreateMessage(IMessage message)
        {
            _messageDictionary[message.Id] = message;
        }

        public IMessage GetMessage(Guid messageId)
        {
            if(_messageDictionary.ContainsKey(messageId))
                return _messageDictionary[messageId];
            return null;
        }

        public void UpdateMessage(Guid messageId, IMessage newMessage)
        {
            _messageDictionary[messageId] = newMessage;
        }

        public void DeleteMessage(Guid messageId)
        {
            _messageDictionary.Remove(messageId);
        }
        
        private readonly Dictionary<Guid, IMessage> _messageDictionary = new Dictionary<Guid, IMessage>();
    }
}