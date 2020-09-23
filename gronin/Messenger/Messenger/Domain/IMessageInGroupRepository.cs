using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IMessageInGroupRepository
    {
        IReadOnlyList<IMessage> Load(Guid groupId);
        void Save(IReadOnlyList<IMessage> messages);
    }
}