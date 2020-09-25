using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Application
{
    public class MessageService
    {
        private readonly IChat _chat;
        private IUserRepository _userRepository;
        public IChat Chat { get; }
        
        public MessageService(IChat chat, IUserRepository userRepository)
        {
            _chat = chat ?? throw new ArgumentNullException(nameof(chat));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void SendMessage(Guid userId, string messageContent)
        {
            var user = _userRepository.Load(userId);
            if (_chat.CanUserSendMessages(user))
            {
                var tempChatMessages = _chat.Messages.ToList();
                tempChatMessages.Add(new Message(messageContent, userId, _chat.Id));
                _chat.Messages = tempChatMessages;
            }
        }

        public IEnumerable<IMessage> ReadMessages(Guid userId)
        {
            if (_chat.Users.Contains(_userRepository.Load(userId)))
            {
                return _chat.Messages;
            }
            return null;
        }

        public void UpdateMessage(Guid userId, string messageContent, Guid messageId)
        {
            var messageToUpdate = _chat.Messages.Where(c => c.Id == messageId)
                .Select(c => c)
                .FirstOrDefault();
            if (Chat.CanUserUpdateMessages(_userRepository.Load(userId), messageToUpdate) && messageToUpdate != null)
            {
                messageToUpdate.UpdateMessageContent(messageContent);
            }
        }

        public void DeleteMessage(Guid userId, Guid messageId)
        {
            var messageToDelete = _chat.Messages.Where(c => c.Id == messageId)
                .Select(c => c)
                .FirstOrDefault();
            
            var user = _userRepository.Load(userId);
            if (Chat.CanUserDeleteMessages(user, messageToDelete) && messageToDelete != null)
            {
                var tempChatMessages = _chat.Messages.ToList();
                tempChatMessages.Remove(messageToDelete);
                _chat.Messages = tempChatMessages;
            }
        }
    }
}