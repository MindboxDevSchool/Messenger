using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public class GroupService : IGroupService
    {
        private readonly IGroupManager _groupManager;

        public GroupService(IGroupManager groupManager)
        {
            _groupManager = groupManager;
        }

        public Guid CreateGroup(Guid createdBy, string name)
        {
           return _groupManager.CreateGroupChat(createdBy, name);
        }

        public Guid CreateMessage(Guid createdBy, Guid groupId, string text)
        {
            return _groupManager.CreateMessage(createdBy, groupId, text);
        }

        public IGroupChat GetGroup(Guid userId, Guid entityId)
        {
            return _groupManager.GetGroup(userId, entityId);
        }

        public void RemoveGroup(Guid userId, Guid groupId)
        {
            _groupManager.RemoveGroup(userId, groupId);
        }

        public void EditMessage(Guid userId, Guid messageId, string newText)
        {
            _groupManager.EditMessage(userId, messageId, newText);
        }

        public void RemoveMessage(Guid userId, Guid groupId, Guid messageId)
        {
            _groupManager.RemoveMessage(userId, groupId, messageId);
        }
    }
}