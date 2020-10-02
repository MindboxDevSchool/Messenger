using System;
using System.Collections.Generic;
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
            if (!channel.Creator.Equals(member))
                _channelRepository.AddMember(channelId, member);
        }

        public void RemoveMember(string memberId, string channelId)
        {
            var member = _userRepository.GetUser(memberId);
            if (!_channelRepository
                .HasMember(channelId, member))
                throw new MemberNotFoundException();
            _channelRepository.RemoveMember(channelId, member);
        }

        public IReadOnlyCollection<IUser> GetMembers(string channelId)
        {
            var channel = _channelRepository.GetChannel(channelId);
            return channel.GetMembers();
        }

        public IMessage SendMessage(string senderId, string channelId, string text)
        {
            var sender = _userRepository.GetUser(senderId);
            var channel = _channelRepository.GetChannel(channelId);
            if (!_channelRepository
                .HasMember(channelId, sender))
                throw new MemberNotFoundException();
            return _messageRepository.CreateMessage(text, sender, channel);
        }

        public void EditMessage(string messageId, string editorId, string newText)
        {
            if (!CanEditorAccessMessage(messageId, editorId))
                throw new AccessErrorException();

            if (newText == "")
                throw new EmptyTextException();
            _messageRepository.EditMessage(messageId, newText);
        }

        public void DeleteMessage(string messageId, string editorId)
        {
            if (!CanEditorAccessMessage(messageId, editorId))
                throw new AccessErrorException();
            _messageRepository.DeleteMessage(messageId);
        }

        public IReadOnlyCollection<IMessage> GetAllMessages(string memberId, string channelId)
        {
            var member = _userRepository.GetUser(memberId);
            var channel = _channelRepository.GetChannel(channelId);
            if (!_channelRepository
                .HasMember(channelId, member))
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