using System;
using System.Collections.Generic;
using Messanger.Domain.MessageModel;

namespace Messanger.Infrastructure
{
    public class MessageRepository : IMessageRepository
    {
        private Dictionary<Guid, IMessage> _messages;
        public Dictionary<Guid, IMessage> Messages
        {
            get { return new Dictionary<Guid, IMessage>(this._messages); }
        }

        public MessageRepository(Dictionary<Guid, IMessage> messages)
        {
            this._messages = new Dictionary<Guid, IMessage>(messages);
        }
        
        public IMessage Load(Guid messageId)
        {
            try
            {
                if (this._messages.ContainsKey(messageId))
                {
                    return this._messages[messageId];
                }
                else
                {
                    throw new Exception($"there is no such message with Guid {messageId}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public void Save(IMessage message)
        {
            try
            {
                if(message.Equals(null))
                    throw new Exception($"IMessage entity is null");
                else
                {
                    this._messages.Add(message.Id, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}