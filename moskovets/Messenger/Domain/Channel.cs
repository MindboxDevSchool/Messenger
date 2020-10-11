using System;
using System.Collections.Generic;
using System.Linq;

namespace Messenger.Domain
{
    public class Channel : IChannel
    {
        public Channel(String id, string name, IUser user)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            CreatorId = user.Id;
            _members = new List<String>();
        }

        public String Id { get; }
        public string Name { get; set; }
        public String CreatorId { get; }
        private List<String> _members;

        public bool HasMember(IUser user)
        {
            return _members.Any(m => m == user.Id);
        }

        public IReadOnlyCollection<String> GetMembers()
        {
            return _members;
        }

        public void AddMember(IUser user)
        {
            if (!HasMember(user))
            {
                _members.Add(user.Id);
            }
        }

        public void RemoveMember(IUser user)
        {
            if (CreatorId == user.Id)
                throw new RemovingCreatorException();
            _members.Remove(user.Id);
        }
    }
}