using System;

namespace Messenger.Domain
{
    public interface IGroupManager
    {
        Guid CreateGroupChat(Guid createdBy, string name);
        Guid CreateMessage(Guid createdBy, Guid groupId, string text);
        GroupChat GetGroup(Guid userId, Guid entityId);
        void RemoveGroup(Guid userId, Guid groupId);
        void EditMessage(Guid userId, Guid messageId, string newText);
        void RemoveMessage(Guid userId, Guid groupId, Guid messageId);
        Message GetMessage(Guid userId, Guid groupId, Guid messageId);
    }

}