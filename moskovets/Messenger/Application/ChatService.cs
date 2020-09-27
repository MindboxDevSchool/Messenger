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

        public void EditMessage(String messageId, String editorId, string newText)
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
        
        public IReadOnlyCollection<IMessage> GetAllMessages(string senderId, string receiverId)
        {
            var sender = _userRepository.GetUser(senderId);
            var receiver = _userRepository.GetUser(receiverId);
            return _messageRepository.GetMessages(sender, receiver);
        }

        public bool CanEditorAccessMessage(string messageId, string editorId)
        {
            var message = _messageRepository.GetMessage(messageId);
            return message.Sender.Id == editorId;
        }
    }
}