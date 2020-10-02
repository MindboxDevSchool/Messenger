using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IGroup : IReceiver
    {
        String Id { get; }
        string Name { get; set; }
        Dictionary<IUser, Role> Roles { get; }

        bool SetRole(IUser user, Role role);
        bool AddUser(IUser user);
        bool RemoveUser(IUser user);
    }
}