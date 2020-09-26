using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public class ChatService : IChatService
    {
        private IUserRepository _userRepository;
        private IMessageRepository _messageRepository;

        public ChatService(IUserRepository userRepository, IMessageRepository messageRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

        public IMessage SendMessage(String senderId, String receiverId, string text)
        {
            var sender = _userRepository.GetUser(senderId);
            var receiver = _userRepository.GetUser(receiverId);
            return _messageRepository.CreateMessage(text, sender, receiver);
        }

        public void EditMessage(String messageId, string newText)
        {
            _messageRepository.EditMessage(messageId, newText);
        }

        public void DeleteMessage(String messageId)
        {
            _messageRepository.DeleteMessage(messageId);
        }

        public IReadOnlyCollection<IMessage> GetAllMessages(string senderId, string receiverId)
        {
            var sender = _userRepository.GetUser(senderId);
            var receiver = _userRepository.GetUser(receiverId);
            return _messageRepository.GetMessages(sender, receiver);
        }
    }
}