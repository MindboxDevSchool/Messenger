using System;

namespace Messenger.Domain
{
    public interface IGroupRepository
    {
        void CreateGroup(IGroup group);
        IGroup GetGroup(Guid groupId);
        void DeleteGroup(Guid groupId);
    }
}