using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IMessageInGroupRepository
    {
        public void CreateMessage(IMessage message);
        IMessage GetMessage(Guid messageId);
        void UpdateMessage(Guid messageId, IMessage newMessage);
        void DeleteMessage(Guid messageId);

    }
}