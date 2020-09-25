using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class ChannelRepository : IChannelRepository
    {
        private Dictionary<Guid, Channel> _channels = new Dictionary<Guid, Channel>();
        private Dictionary<Guid, Message> _messages = new Dictionary<Guid, Message>();
        public void Save(Channel channel)
        {
            _channels.Add(channel.Id, channel);
        }

        public void SaveMessage(Message message)
        {
            _messages.Add(message.Id, message);
        }

        public Channel GetChannel(Guid entityId)
        {
            return _channels[entityId];
        }

        public void RemoveChannel(Guid entityId)
        {
            _channels.Remove(entityId);
        }

        public void AddUser(Guid userId, Guid channelId)
        {
            _channels[channelId].Users.Add(userId);
        }

        public void EditMessage(Message message)
        {
            _messages[message.Id] = message;
        }

        public Message GetMessage(Guid messageId)
        {
            return _messages[messageId];
        }

        public void RemoveMessage(Guid messageId)
        {
            _messages.Remove(messageId);
        }

        public void AddAdmin(Guid adminId, Guid channelId)
        {
            _channels[channelId].Admins.Add(adminId);
        }

    }
}