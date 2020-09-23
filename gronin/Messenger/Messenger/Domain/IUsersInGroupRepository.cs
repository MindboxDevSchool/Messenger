using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUsersInGroupRepository
    {
        ICollection<IUserInGroup> LoadByGroup(Guid groupId);
        ICollection<IUserInGroup> LoadByUser(Guid userId);
        void Save(IReadOnlyList<IUserInGroup> users);
    }
}