using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IMessageInGroupRepository
    {
        ICollection<IMessage> Load(Guid groupId);
        void Save(IReadOnlyList<IMessage> messages, Guid groupId);
    }
}