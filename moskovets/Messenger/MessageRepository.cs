using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger
{
    public class MessageRepository : IMessageRepository
    {
        private List<IMessage> _messages;

        public MessageRepository()
        {
            _messages = new List<IMessage>();
        }

        public IMessage CreateMessage(string text, ISender sender, IReceiver receiver)
        {
            var id = Guid.NewGuid().ToString("N");
            var data = DateTime.Now;
            var message = new Message(id, text, sender, receiver, data);
            _messages.Add(message);
            return message;
        }

        public IMessage EditMessage(String id, string newText)
        {
            var message = GetMessage(id);
            message.Text = newText;
            return message;
        }

        public void DeleteMessage(String id)
        {
            _messages.RemoveAll(m => m.Id == id); 
        }

        public IReadOnlyCollection<IMessage> GetMessages(ISender sender, IReceiver receiver)
        {
            var messages = _messages
                .Where(m => 
                    m.Sender.Equals(sender) && m.Receiver.Equals(receiver) || 
                    m.Sender.Equals(receiver) && m.Receiver.Equals(sender))
                .OrderByDescending(m => m.SentAt).ToList();
            
            return messages;
        }

        public IReadOnlyCollection<IMessage> GetMessages(IReceiver receiver)
        {
            var messages = _messages
                .Where(m => m.Receiver.Equals(receiver))
                .OrderByDescending(m => m.SentAt).ToList();
            
            return messages;
        }

        public IMessage GetMessage(string id)
        {
            var message = _messages.FirstOrDefault(m => m.Id == id);
            if (message == null)
                throw new NotFoundException();
            return message;
        }
    }
}