using System;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public class ChannelService : IChannelService
    {
        private IChannelManager _channelManager;

        public ChannelService(IChannelManager channelManager)
        {
            _channelManager = channelManager;
        }

        public Guid CreateChannel(Guid createdBy, string name)
        {
            return _channelManager.CreateChannel(createdBy, name);
        }
        
        public Guid CreateMessage(Guid createdBy, Guid channelId, string text)
        {
            return _channelManager.CreateMessage(createdBy, channelId, text);
        }

        public IChannel GetChannel(Guid userId, Guid channelId)
        {
            return _channelManager.GetChannel(userId, channelId);
        }

        public void RemoveChannel(Guid userId, Guid channelId)
        {
            _channelManager.RemoveChannel(userId, channelId);
        }

        public void AddAdmin(Guid adminId, Guid userId, Guid channelId)
        {
            _channelManager.AddAdmin(adminId, userId, channelId);
        }

        public void AddUser(Guid adminId, Guid userId, Guid channelId)
        {
            _channelManager.AddUser(adminId, userId, channelId);
        }

        public void EditMessage(Guid userId, Guid channelId, Guid messageId, string newText)
        {
            _channelManager.EditMessage(userId, channelId, messageId, newText);
        }

        public void RemoveMessage(Guid userId, Guid channelId, Guid messageId)
        {
            _channelManager.RemoveMessage(userId, channelId, messageId);
        }
    }
}