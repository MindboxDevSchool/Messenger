using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IGroup : IReceiver
    {
        String Id { get; }
        string Name { get; set; }
        String CreatorId { get; }

        void SetRole(IUser user, Role role);
        void AddMember(IUser user);
        void RemoveMember(IUser user);
        bool HasMember(IUser user);
        Role GetRole(IUser user);
        IReadOnlyCollection<String> GetMembers();
    }
}