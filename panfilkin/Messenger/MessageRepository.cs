using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger
{
    public class MessageRepository : IMessageRepository
    {
        private List<IMessage> Messages { get; }

        public MessageRepository()
        {
            Messages = new List<IMessage>();
        }

        public IMessage Load(Guid messageId)
        {
            try
            {
                return Messages.Single(message => message.Id == messageId);
            }
            catch (Exception)
            {
                throw new NotFoundException("Message with selected id not found!");
            }
        }

        public void Save(IMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (Messages.Count(chatInList => chatInList == message) == 0)
            {
                Messages.Add(message);
            }
        }
    }
}