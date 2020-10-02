using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IGroupService
    {
        IGroup CreateGroup(String creatorId, string name);
        void AddMember(String memberId, String groupId);
        void RemoveMember(String memberId, String groupId);
        void ChangeRole(String memberId, Role role, String groupId);
        IReadOnlyCollection<IUser> GetMembers(String channelId);
    }
}