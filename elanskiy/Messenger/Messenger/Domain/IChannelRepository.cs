using System;

namespace Messenger.Domain
{
    public interface IChannelRepository
    {
        void Save(Channel channel);
        void SaveMessage(Message message);
        Channel GetChannel(Guid entityId);
        void RemoveChannel(Guid entityId);
        void AddUser(Guid userId, Guid channelId);
        void EditMessage(Message message);
        Message GetMessage(Guid messageId);
        void RemoveMessage(Guid messageId);
        void AddAdmin(Guid adminId, Guid channelId);
    }
}