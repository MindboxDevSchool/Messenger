using System;
using Domain;
using Domain.Repositories;

namespace Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatRepository _chatRepository;
        private IUserPermissionsForMessageChecker _permissionsChecker;

        public MessageService(IMessageRepository messageRepository, IContext context, IUserPermissionsForMessageChecker permissionsChecker, IChatRepository chatRepository)
        {
            _messageRepository = messageRepository;
            _permissionsChecker = permissionsChecker;
            _chatRepository = chatRepository;
        }

        public Guid AddMessage(Guid authorId, Guid chatId, string content)
        {
            var chat = _chatRepository.GetChat(chatId);
            if (!chat.UserHasPermissionsToPost(authorId))
                throw new Exception();
            var id = new Guid();
            var timePosted = DateTime.Now;
            var message = new Message(id, authorId, chatId, timePosted, content);
            _messageRepository.AddMessage(message);
            return id;
        }

        public IMessage GetMessage(Guid id)
        {
            return _messageRepository.GetMessage(id);
        }

        public void UpdateMessage(Guid id, string content)
        {
            var message = _messageRepository.GetMessage(id);
            var chat = _chatRepository.GetChat(chatId);

        }

        public void DeleteMessage(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}