using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Group : IGroup
    {
        private Dictionary<String, Role> _roles;

        public Group(String id, string name, IUser creator)
        {
            if (creator == null) throw new ArgumentNullException(nameof(creator));
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CreatorId = creator.Id;
            _roles = new Dictionary<String, Role>();
            _roles.Add(creator.Id, Role.Admin);
        }

        public String Id { get; }
        public string Name { get; set; }
        public String CreatorId { get; }

        public void SetRole(IUser user, Role role)
        {
            if (_roles.ContainsKey(user.Id))
                _roles.Remove(user.Id);
            _roles.Add(user.Id, role);
        }

        public void AddMember(IUser user)
        {
            if (!_roles.ContainsKey(user.Id))
                _roles.Add(user.Id, Role.Default);
        }

        public void RemoveMember(IUser user)
        {
            _roles.Remove(user.Id);
        }

        public bool HasMember(IUser user)
        {
            return _roles.ContainsKey(user.Id);
        }

        public Role GetRole(IUser user)
        {
            return _roles.GetValueOrDefault(user.Id);
        }

        public IReadOnlyCollection<string> GetMembers()
        {
            return _roles.Keys;
        }
    }
}