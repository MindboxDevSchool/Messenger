using System;
using System.Collections.Generic;
using System.Linq;

namespace Messenger.Domain
{
    public class Chanel : IChanel
    {
        public Chanel(String id, string name, IUser user)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Creator = user ?? throw new ArgumentNullException(nameof(user));
            _members = new List<IUser>();
        }

        public String Id { get; }
        public string Name { get; set; }
        public IUser Creator { get; }
        private List<IUser> _members;

        public IReadOnlyCollection<IUser> GetMembers()
        {
            return _members;
        }
        public void AddMember(IUser user)
        {
            if (!_members.Any(u => u.Equals(user)))
            {
                _members.Add(user);
            }
        }
        public void RemoveMember(IUser user)
        {
            if (Creator.Equals(user))
                throw new RemovingCreatorException();
            _members.RemoveAll(u => u.Equals(user));
        }
    }
}