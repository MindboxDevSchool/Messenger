using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IGroup : IReceiver
    {
        public String Id { get; }
        public string Name { get; set; }
        public Dictionary<IUser, Role> Roles { get; }

        public bool SetRole(IUser user, Role role);

        public bool AddUser(IUser user);

        public bool RemoveUser(IUser user);
    }
}