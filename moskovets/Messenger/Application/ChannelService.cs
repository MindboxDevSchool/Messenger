using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Application
{
    public class ChannelService : IChannelService, IChatService
    {
        private IUserRepository _userRepository;
        private IMessageRepository _messageRepository;
        private IChannelRepository _channelRepository;

        public ChannelService(IUserRepository userRepository,
            IMessageRepository messageRepository,
            IChannelRepository channelRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _channelRepository = channelRepository ?? throw new ArgumentNullException(nameof(channelRepository));
        }

        public IChannel CreateChannel(string creatorId, string name)
        {
            var creator = _userRepository.GetUser(creatorId);
            return _channelRepository.CreateChannel(creator, name);
        }

        public void AddMember(string memberId, string channelId)
        {
            var member = _userRepository.GetUser(memberId);
            var channel = _channelRepository.GetChannel(channelId);
            if (channel.CreatorId != memberId)
                channel.AddMember(member);
        }

        public void RemoveMember(string memberId, string channelId)
        {
            var member = _userRepository.GetUser(memberId);
            var channel = _channelRepository.GetChannel(channelId);
            if (!channel.HasMember(member))
                throw new MemberNotFoundException();
            channel.RemoveMember(member);
        }

        public IReadOnlyCollection<IUser> GetMembers(string channelId)
        {
            var channel = _channelRepository.GetChannel(channelId);
            var users = channel.GetMembers();
            return users.Select(uId => _userRepository.GetUser(uId)).ToList();
        }

        public IMessage SendMessage(string senderId, string channelId, string text)
        {
            var sender = _userRepository.GetUser(senderId);
            var channel = _channelRepository.GetChannel(channelId);
            if (!channel.HasMember(sender))
                throw new MemberNotFoundException();
            return _messageRepository.CreateMessage(text, sender, channel);
        }

        public void EditMessage(string messageId, string editorId, string newText)
        {
            if (!CanEditorAccessMessage(messageId, editorId))
                throw new InvalidAccessException();

            if (String.IsNullOrEmpty(newText))
                throw new InvalidTextException();
            _messageRepository.EditMessage(messageId, newText);
        }

        public void DeleteMessage(string messageId, string editorId)
        {
            if (!CanEditorAccessMessage(messageId, editorId))
                throw new InvalidAccessException();
            _messageRepository.DeleteMessage(messageId);
        }

        public IReadOnlyCollection<IMessage> GetAllMessages(string memberId, string channelId)
        {
            var member = _userRepository.GetUser(memberId);
            var channel = _channelRepository.GetChannel(channelId);
            if (!channel.HasMember(member))
                throw new MemberNotFoundException();

            return _messageRepository.GetMessages(channel);
        }

        public bool CanEditorAccessMessage(string messageId, string editorId)
        {
            var message = _messageRepository.GetMessage(messageId);
            return message.Sender.Id == editorId;
        }
    }
}