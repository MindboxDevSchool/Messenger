using System;

namespace Messenger.Domain
{
    public interface IUser
    {
        Guid Id { get; }
        string Name { get; }
        string Phone { get; }
        bool HaveAccessTo(Guid chatId, AccessType accessType);
    }
}