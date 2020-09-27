using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Message;
using Domain.Repositories;
using static Domain.User.UserPermissionExtensions;

namespace Application.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IContext _context;
        private readonly IUserRepository _userRepository;


        public MessageService(IMessageRepository messageRepository,
            IChatRepository chatRepository, IUserRepository userRepository, IContext context)
        {
            _messageRepository = messageRepository;
            _chatRepository = chatRepository;
            _userRepository = userRepository;
            _context = context;
        }

        public Guid AddMessage(Guid chatId, string content)
        {
            var currentUserId = _context.GetCurrentUserId();
            var currentUser = _userRepository.GetUser(currentUserId);
            var chat = _chatRepository.GetChat(chatId);
            if (!currentUser.HasPermissionToPostMessage(chat))
                throw new Exception();
            
            var messageId = new Guid();
            var messageContent = new MessageContent(content);
            var message = new Message(messageId, currentUserId, chat, DateTime.Now, messageContent);

            _messageRepository.AddMessage(message);
            return messageId;
        }

        public IMessage GetMessage(Guid messageId)
        {
            var currentUserId = _context.GetCurrentUserId();
            var currentUser = _userRepository.GetUser(currentUserId);
            var message = _messageRepository.GetMessage(messageId);
            
            if (!currentUser.HasPermissionToReadFromChat(message.Chat))
                throw new Exception();

            return message;
        }

        public IReadOnlyList<IMessage> GetLastMessages(Guid chatId, int numberOfMessages)
        {
            var currentUserId = _context.GetCurrentUserId();
            var currentUser = _userRepository.GetUser(currentUserId);
            var chat = _chatRepository.GetChat(chatId);
            
            if (!currentUser.HasPermissionToReadFromChat(chat))
                throw new Exception();

            return chat.Messages
                .Take(numberOfMessages)
                .ToList();
        }

        public void EditMessage(Guid messageId, string newContent)
        {
            var currentUserId = _context.GetCurrentUserId();
            var currentUser = _userRepository.GetUser(currentUserId);
            var messageToEdit = _messageRepository.GetMessage(messageId);
            
            if (!currentUser.HasPermissionToEditMessage(messageToEdit))
                throw new Exception();

            var newMessage = messageToEdit.Edit(new MessageContent(newContent));
            _messageRepository.AddMessage(newMessage);
        }

        public void DeleteMessage(Guid messageId)
        {
            var currentUserId = _context.GetCurrentUserId();
            var currentUser = _userRepository.GetUser(currentUserId);
            var messageToDelete = _messageRepository.GetMessage(messageId);
            
            if (!currentUser.HasPermissionToDeleteMessage(messageToDelete))
                throw new Exception();

            _messageRepository.DeleteMessage(messageToDelete.Id);
        }
    }
}