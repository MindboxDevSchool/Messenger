using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public class ChanelService : IChanelService
    {
        private IUserRepository _userRepository;
        private IMessageRepository _messageRepository;
        private IChanelRepository _chanelRepository;

        public ChanelService(IUserRepository userRepository, IMessageRepository messageRepository,
            IChanelRepository chanelRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _chanelRepository = chanelRepository ?? throw new ArgumentNullException(nameof(chanelRepository));
        }

        public IChanel CreateChanel(string creatorId, string name)
        {
            var creator = _userRepository.GetUser(creatorId);
            return _chanelRepository.CreateChanel(creator, name);
        }

        public void AddMember(string memberId, string channelId)
        {
            var member = _userRepository.GetUser(memberId);
            var chanel = _chanelRepository.GetChanel(channelId);
            if (!chanel.Creator.Equals(member))
                _chanelRepository.AddMember(channelId, member);
        }

        public void RemoveMember(string memberId, string channelId)
        {
            var member = _userRepository.GetUser(memberId);
            var chanel = _chanelRepository.GetChanel(channelId);
            if (!_chanelRepository
                .HasMember(channelId, member))
                throw new MemberNotFoundException();
            _chanelRepository.RemoveMember(channelId, member);
        }

        public IReadOnlyCollection<IUser> GetMembers(string channelId)
        {
            var chanel = _chanelRepository.GetChanel(channelId);
            return chanel.GetMembers();
        }

        public IMessage SendMessage(string senderId, string channelId, string text)
        {
            var sender = _userRepository.GetUser(senderId);
            var chanel = _chanelRepository.GetChanel(channelId);
            if (!_chanelRepository
                .HasMember(channelId, sender))
                throw new MemberNotFoundException();
            return _messageRepository.CreateMessage(text, sender, chanel);
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
            var chanel = _chanelRepository.GetChanel(channelId);
            if (!_chanelRepository
                .HasMember(channelId, member))
                throw new MemberNotFoundException();
            
            return _messageRepository.GetMessages(chanel);
        }

        public bool CanEditorAccessMessage(string messageId, string editorId)
        {
            var message = _messageRepository.GetMessage(messageId);
            return message.Sender.Id == editorId;
        }
    }
}