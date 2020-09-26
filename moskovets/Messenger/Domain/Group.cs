using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Group : IGroup
    {
        public Group(String id, string name, IUser creator)
        {
            if (creator == null) throw new ArgumentNullException(nameof(creator));
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));

            Roles = new Dictionary<IUser, Role>();
            Roles.Add(creator, Role.Admin);
        }

        public String Id { get; }
        public string Name { get; set; }
        public Dictionary<IUser, Role> Roles { get; }

        public bool SetRole(IUser user, Role role)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(IUser user)
        {
            throw new NotImplementedException();
        }
    }
}