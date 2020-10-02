using System;
using System.Collections.Generic;
using Messeger.Domain;

namespace Messeger.Infrastructure
{
    public class ChatRepository : IChatRepository
    {
        public IEnumerable<Message> GetLatestMessages()
        {
            throw new NotImplementedException();
        }

        public void PushMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(Guid messageId)
        {
            throw new NotImplementedException();
        }

        public void EditMessage(Guid messageId)
        {
            throw new NotImplementedException();
        }
    }
}