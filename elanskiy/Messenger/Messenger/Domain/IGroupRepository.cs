using System;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IGroupRepository
    {
        void Save(GroupChat groupChat);
        GroupChat GetGroup(Guid groupId);
        void RemoveGroup(Guid groupId);
        void AddUser(Guid userId, Guid groupId);
        void SaveMessage(Message message);
        Message GetMessage(Guid messageId);
        void AddAdmin(Guid userId, Guid groupId);
        void EditMessage(Message message);
        void RemoveMessage(Guid messageId);
    }
}