using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IChannel : IReceiver
    {
        String Id { get; }
        string Name { get; set; }
        IUser Creator { get; }
        void AddMember(IUser user);
        void RemoveMember(IUser user);
        bool HasMember(IUser user);
        IReadOnlyCollection<IUser> GetMembers();
    }
}