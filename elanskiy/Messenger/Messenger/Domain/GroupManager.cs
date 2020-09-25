using System;
using System.Linq;
using Messenger.Infrastructure;

namespace Messenger.Domain
{
    public class GroupManager : IGroupManager
    {
        private readonly IGroupRepository _groupRepository;

        public GroupManager(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public Guid CreateGroupChat(Guid createdBy, string name)
        {
            var groupChat = new GroupChat(Guid.NewGuid(), createdBy, name);
            _groupRepository.Save(groupChat);
            return groupChat.Id;
        }
        
        public Guid CreateMessage(Guid createdBy, Guid groupId, string text)
        {
            var group = _groupRepository.GetGroup(groupId) ?? 
                        throw new ApplicationException("Group not found!");
            
            if (!(group.Users.Contains(createdBy) || group.Admins.Contains(createdBy)))
                throw new ApplicationException("Not enough rights!");
            
            var message = new Message(Guid.NewGuid(), createdBy, groupId, text);
            _groupRepository.SaveMessage(message);
            return message.Id;
        }

        public GroupChat GetGroup(Guid userId, Guid entityId)
        {
            var group = _groupRepository.GetGroup(entityId) ?? 
                       throw new ApplicationException("Group not found!");
            if (!(group.Users.Contains(userId) || group.Admins.Contains(userId)))
                throw new ApplicationException("Not enough rights!");
            return group;
        }

        public void RemoveGroup(Guid userId, Guid groupId)
        {
            var group = _groupRepository.GetGroup(groupId) ?? 
                        throw new ApplicationException("Group not found!");
            if (!group.Admins.Contains(userId))
                throw new ApplicationException("Not enough rights!");
            _groupRepository.RemoveGroup(groupId);
        }

        public void AddAdmin(Guid adminId, Guid userId, Guid groupId)
        {
            var group = _groupRepository.GetGroup(groupId) ?? 
                        throw new ApplicationException("Group not found!");
            if (!group.Admins.Contains(adminId))
                throw new ApplicationException("Not enough rights!");
            _groupRepository.AddAdmin(userId, groupId);
        }

        public void AddUser(Guid adminId, Guid userId, Guid groupId)
        {
            var group = _groupRepository.GetGroup(groupId) ?? 
                        throw new ApplicationException("Group not found!");
            if (!group.Admins.Contains(adminId))
                throw new ApplicationException("Not enough rights!");
            _groupRepository.AddUser(userId, groupId);
        }

        public void EditMessage(Guid userId, Guid messageId, string newText)
        {
            var message = _groupRepository.GetMessage(messageId) ?? 
                          throw new ApplicationException("The message not found!");
            if (message.CreatedBy != userId)
                throw new ApplicationException("Not enough rights!");
            message.Text = newText;
            _groupRepository.EditMessage(message);
        }

        public void RemoveMessage(Guid userId, Guid groupId, Guid messageId)
        {
            var group = _groupRepository.GetGroup(groupId) ?? 
                       throw new ApplicationException("Group not found!");
            
            var message = _groupRepository.GetMessage(messageId) ?? 
                          throw new ApplicationException("The message not found!");
            
            if (message.CreatedBy == userId || group.Admins.Contains(userId))
                _groupRepository.RemoveMessage(messageId);
            else
                throw new ApplicationException("Not enough rights!");
        }

        public Message GetMessage(Guid userId, Guid groupId, Guid messageId)
        {
            var group = _groupRepository.GetGroup(groupId) ?? 
                        throw new ApplicationException("Group not found!");
            
            if (!(group.Admins.Contains(userId) || group.Users.Contains(userId)))
                throw new ApplicationException("Not enough rights!"); 
            
            var message = _groupRepository.GetMessage(messageId) ?? 
                          throw new ApplicationException("The message not found!");

            return message;
        }

    }
}