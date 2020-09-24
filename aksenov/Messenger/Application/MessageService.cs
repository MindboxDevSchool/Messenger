using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;
using Messenger.Exceptions;

namespace Messenger.Application
{
    public class MessageService : IMessageService
    {
        public MessageService(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }
        
        public void SendMessage(Guid chatId, Guid userId, string content, DateTime date)
        {
            var chat = _chatRepository.GetBy(chatId);
            var user = _userRepository.GetBy(userId);
            var isAccessed = user.HaveAccessTo(chatId, AccessType.Write);
            if (isAccessed)
            {
                var message = Message.Create(userId, content, date);
                chat.PostMessage(message);
                _chatRepository.Update(chat);
            }
        }

        public IEnumerable<Message> RequestNewMessages(Guid chatId, Guid userId)
        {
            var user = _userRepository.GetBy(userId);
            if (user.AvailableChats.ContainsKey(chatId))
            {
                var newMessages = _chatRepository.LoadNewFor(chatId);
                return newMessages;
            }
            
            throw new ChatNotFoundException(chatId);
        }

        public void DeleteMessage(Guid chatId, Guid userId, Guid messageId, bool isOwnMessage)
        {
            var chat = _chatRepository.GetBy(chatId);
            var user = _userRepository.GetBy(userId);
            var isAccessed = isOwnMessage
                            ? user.HaveAccessTo(chatId, AccessType.DeleteOwn)
                            : user.HaveAccessTo(chatId, AccessType.DeleteSomeone);
            if (isAccessed)
            {
                chat.TryDeleteMessage(messageId);
                _chatRepository.Update(chat);
            }
        }

        public void EditMessage(Guid chatId, Guid userId, Message message)
        {
            var chat = _chatRepository.GetBy(chatId);
            var user = _userRepository.GetBy(userId);
            var isAccessed = user.HaveAccessTo(chatId, AccessType.Edit);
            if (isAccessed)
            {
                chat.TryUpdateMessage(message);
                _chatRepository.Update(chat);
            }
        }

        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;
    }
}