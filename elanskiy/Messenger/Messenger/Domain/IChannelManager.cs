using System;

namespace Messenger.Domain
{
    public interface IChannelManager
    {
        Guid CreateChannel(Guid createdBy, string name);
        Guid CreateMessage(Guid createdBy, Guid channelId, string text);
        Channel GetChannel(Guid userId, Guid entityId);
        void RemoveChannel(Guid userId, Guid channelId);
        void AddAdmin(Guid adminId, Guid userId, Guid channelId);
        void AddUser(Guid adminId, Guid userId, Guid channelId);
        void EditMessage(Guid userId, Guid channelId, Guid messageId, string newText);
        void RemoveMessage(Guid userId, Guid channelId, Guid messageId);
        Message GetMessage(Guid userId, Guid channelId, Guid messageId);
    }
}