using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IGroupService
    {
        Guid CreateGroup(Guid createdBy, string name);
        Guid CreateMessage(Guid createdBy, Guid groupId, string text);
        IGroupChat GetGroup(Guid userId, Guid entityId);
        void RemoveGroup(Guid userId, Guid groupId);
        void EditMessage(Guid userId, Guid messageId, string newText);
        void RemoveMessage(Guid userId, Guid groupId, Guid messageId);
    }
}