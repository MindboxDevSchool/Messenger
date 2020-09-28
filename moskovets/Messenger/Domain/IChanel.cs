using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IChanel : IReceiver
    {
        public String Id { get; }
        public string Name { get; set; }
        public IUser Creator { get; }
        public void AddMember(IUser user);
        public void RemoveMember(IUser user);
        public IReadOnlyCollection<IUser> GetMembers();
    }
}