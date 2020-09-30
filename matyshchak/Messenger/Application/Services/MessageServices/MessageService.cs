using System;
using System.Collections.Generic;
using Domain.Chats;
using Domain.Message;
using Domain.Repository;
using Domain.User;
using Domain.UserPermissions;
using Domain.UserPermissions.Exceptions;

namespace Application.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        public MessageService(
            IContext context,
            IRepository<IChat> chatRepository,
            IRepository<IUser> userRepository,
            IRepository<IMessage> messageRepository)
        {
            _context = context;
            _chatRepository = chatRepository;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
        }

        private readonly IContext _context;

        private readonly IRepository<IChat> _chatRepository;

        private readonly IRepository<IUser> _userRepository;

        private readonly IRepository<IMessage> _messageRepository;

        public Guid Post(Guid chatId, MessageContent messageContent)
        {
            var currentUser = _userRepository.Find(_context.CurrentUserId);
            var chat = _chatRepository.Find(chatId);
            
            if (!currentUser.IsMemberOf(chat))
                throw new NotMemberOfChatException();
            
            if (!currentUser.HasPermissionToPostTo(chat))
                throw new NoPermissionToPostMessageException();
            
            var messageId = Guid.NewGuid();
            var message = Message.Create(messageId, currentUser, chat, messageContent);
            _messageRepository.Add(message);
            
            return messageId;
        }

        public IEnumerable<IMessage> Read(Guid chatId)
        {
            var currentUser = _userRepository.Find(_context.CurrentUserId);
            var chat = _chatRepository.Find(chatId);
            
            if (!currentUser.IsMemberOf(chat))
                throw new NotMemberOfChatException();
            
            return chat.Messages;
        }

        public void Edit(Guid messageId, MessageContent newContent)
        {
            var currentUser = _userRepository.Find(_context.CurrentUserId);
            var message = _messageRepository.Find(messageId);
            
            if (!currentUser.HasPermissionToEdit(message))
                throw new NoPermissionToEditMessageException();

            var newMessage = message.Edit(newContent);
            _messageRepository.Update(newMessage);
        }

        public void Delete(Guid messageId)
        {
            var currentUser = _userRepository.Find(_context.CurrentUserId);
            var message = _messageRepository.Find(messageId);

            if (!currentUser.HasPermissionToDeleteMessage(message))
                throw new NoPermissionToDeleteMessageException();

            _messageRepository.Delete(messageId);
        }
    }
}