using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger
{
    public class MessageInGroupRepository:IMessageInGroupRepository
    {
        public ICollection<IMessage> Load(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public void Save(IReadOnlyList<IMessage> messages, Guid groupId)
        {
            throw new NotImplementedException();
        }
    }
}