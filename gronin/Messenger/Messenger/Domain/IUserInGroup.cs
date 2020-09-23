using System;

namespace Messenger.Domain
{
    public interface IUserInGroup
    {
        Guid UserId { get; }
        Guid GroupId { get; }
        bool IsAdmin { get; }
        bool IsOwner { get; }
        IUser User { get; }
        IGroup Group { get; }
    }
}