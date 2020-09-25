using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChannelService
    {
        Guid CreateChannel(Guid createdBy, string name);
        Guid CreateMessage(Guid createdBy, Guid channelId, string text);
        IChannel GetChannel(Guid userId, Guid channelId);
        void RemoveChannel(Guid userId, Guid channelId);
        void AddAdmin(Guid adminId, Guid userId, Guid channelId);
        void AddUser(Guid adminId, Guid userId, Guid channelId);
        void EditMessage(Guid userId, Guid channelId, Guid messageId, string newText);
    }
}