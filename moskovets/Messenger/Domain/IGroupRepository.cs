using System;

namespace Messenger.Domain
{
    public interface IGroupRepository
    {
        IGroup CreateGroup(IUser creator, string name);
        IGroup GetGroup(String groupId);
        void EditGroup(String groupId, string newName);
        void DeleteGroup(String groupId);
    }
}