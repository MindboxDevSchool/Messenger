using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class GroupRepository : IGroupRepository
    {
        private Dictionary<Guid, GroupChat> _groupChats = new Dictionary<Guid, GroupChat>();
        private Dictionary<Guid, Message> _messages = new Dictionary<Guid, Message>();
        public void Save(GroupChat groupChat)
        {
            _groupChats.Add(groupChat.Id, groupChat);
        }

        public GroupChat GetGroup(Guid groupId)
        {
            return _groupChats[groupId];
        }

        public void RemoveGroup(Guid groupId)
        {
            _groupChats.Remove(groupId);
        }

        public void AddUser(Guid userId, Guid groupId)
        {
            _groupChats[groupId].Users.Add(userId);
        }

        public void AddAdmin(Guid userId, Guid groupId)
        {
            _groupChats[groupId].Admins.Add(userId);
        }

        public void SaveMessage(Message message)
        {
            _messages.Add(message.Id, message);
        }

        public Message GetMessage(Guid messageId)
        {
            return _messages[messageId];
        }

        public void RemoveMessage(Guid messageId)
        {
            _messages.Remove(messageId);
        }

        public void EditMessage(Message message)
        {
            _messages[message.Id] = message;
        }
    }
}