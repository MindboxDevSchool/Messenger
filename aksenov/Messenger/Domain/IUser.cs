using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUser
    {
        Guid Id { get; }
        string Name { get; }
        string Phone { get; }
        Dictionary<Guid, ChatRole> AvailableChats { get; }
        bool HaveAccessTo(Guid chatId, AccessType accessType);
    }
}