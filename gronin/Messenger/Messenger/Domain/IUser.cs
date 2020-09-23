using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUser
    {
        Guid Id { get; }
        Guid Name { get; set; }
        ICollection<UserInGroup> UserGroups { get; }
    }
}