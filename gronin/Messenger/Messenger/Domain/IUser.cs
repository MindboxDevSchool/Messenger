using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUser
    {
        Guid Id { get; }
        Guid Name { get; }
        ICollection<UserInGroup> UserGroups { get; }
    }
}