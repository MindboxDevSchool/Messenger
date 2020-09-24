using System;

namespace Messenger.Domain
{
    public interface IChatFactory
    {
        IChat Create(ChatType chatType, string name, Guid creatorId);
    }
}