using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUsersInGroupRepository
    {
        IReadOnlyList<IUserInGroup> Load(Guid groupId);
        void Save(IReadOnlyList<IUserInGroup> users);
    }
}