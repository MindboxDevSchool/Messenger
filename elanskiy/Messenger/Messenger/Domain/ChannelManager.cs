using System;
using Messenger.Infrastructure;

namespace Messenger.Domain
{
    public class ChannelManager : IChannelManager
    {
        private readonly IChannelRepository _channelRepository;

        public ChannelManager(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }

        public Guid CreateChannel(Guid createdBy, string name)
        {
            var channel = new Channel(Guid.NewGuid(), createdBy, name);
            _channelRepository.Save(channel);
            return channel.Id;
        }
        
        public Guid CreateMessage(Guid createdBy, Guid channelId, string text)
        {
            var channel = _channelRepository.GetChannel(channelId) ?? 
                        throw new ApplicationException("Channel not found!");
            
            if (!channel.Admins.Contains(createdBy))
                throw new ApplicationException("Not enough rights!");
            
            var message = new Message(Guid.NewGuid(), createdBy, channelId, text);
            _channelRepository.SaveMessage(message);
            return message.Id;
        }

        public Channel GetChannel(Guid userId, Guid entityId)
        {
            var channel = _channelRepository.GetChannel(entityId) ?? 
                       throw new ApplicationException("Channel not found!");
            if (!(channel.Users.Contains(userId) || channel.Admins.Contains(userId)))
                throw new ApplicationException("Not enough rights!");
            return channel;
        }

        public void RemoveChannel(Guid userId, Guid channelId)
        {
            var channel = _channelRepository.GetChannel(channelId) ?? 
                          throw new ApplicationException("Group not found!");
            if (!channel.Admins.Contains(userId))
                throw new ApplicationException("Not enough rights!");
            _channelRepository.RemoveChannel(channelId);
        }

        public void AddAdmin(Guid adminId, Guid userId, Guid channelId)
        {
            var channel = _channelRepository.GetChannel(channelId) ?? 
                        throw new ApplicationException("Group not found!");
            if (!channel.Admins.Contains(adminId))
                throw new ApplicationException("Not enough rights!");
            _channelRepository.AddAdmin(userId, channelId);
        }

        public void AddUser(Guid adminId, Guid userId, Guid channelId)
        {
            var channel = _channelRepository.GetChannel(channelId) ?? 
                          throw new ApplicationException("Group not found!");
            if (!channel.Admins.Contains(adminId))
                throw new ApplicationException("Not enough rights!");
            _channelRepository.AddUser(userId, channelId);
        }

        public void EditMessage(Guid userId, Guid channelId, Guid messageId, string newText)
        {
            var message = _channelRepository.GetMessage(messageId) ?? 
                          throw new ApplicationException("The message not found!");
            var channel = _channelRepository.GetChannel(channelId) ?? 
                          throw new ApplicationException("Group not found!");
            if (!channel.Admins.Contains(userId))
                throw new ApplicationException("Not enough rights!");
            message.Text = newText;
            _channelRepository.EditMessage(message);
        }

        public void RemoveMessage(Guid userId, Guid channelId, Guid messageId)
        {
            var channel = _channelRepository.GetChannel(channelId) ?? 
                       throw new ApplicationException("Group not found!");
            
            var message = _channelRepository.GetMessage(messageId) ?? 
                          throw new ApplicationException("The message not found!");
            
            if (channel.Admins.Contains(userId))
                _channelRepository.RemoveMessage(messageId);
            else
                throw new ApplicationException("Not enough rights!");
        }

        public Message GetMessage(Guid userId, Guid channelId, Guid messageId)
        {
            var channel = _channelRepository.GetChannel(channelId) ?? 
                          throw new ApplicationException("Group not found!");
            
            var message = _channelRepository.GetMessage(messageId) ?? 
                          throw new ApplicationException("The message not found!");

            return message;
        }
    }
}