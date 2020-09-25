using System;
using System.Linq;
using Messenger.Infrastructure;

namespace Messenger.Domain
{
    public class PrivateChatManager : IPrivateChatManager
    {
        private readonly IPrivateChatRepository _privateChatRepository;

        public PrivateChatManager(IPrivateChatRepository privateChatRepository)
        {
            _privateChatRepository = privateChatRepository;
        }

        public Guid CreatePrivateChat(Guid from, Guid to)
        {
            var chat = new PrivateChat(Guid.NewGuid(), new[]{from, to});
            _privateChatRepository.SaveChat(chat);
            return chat.Id;
        }
        
        public Guid CreateMessage(Guid from, Guid to, string text)
        {
            var message = new Message(Guid.NewGuid(), from, to, text);
            _privateChatRepository.SaveMessage(message);
            return message.Id;
        }

        public PrivateChat GetChat(Guid userId, Guid entityId)
        {
            var chat = _privateChatRepository.GetChat(entityId) ?? 
                throw new ApplicationException("Chat not found!");
            CheckUserInChat(chat, userId);
            return chat;
        }

        public void RemoveChat(Guid userId, Guid entityId)
        {
            var chat = _privateChatRepository.GetChat(entityId) ?? 
                       throw new ApplicationException("Chat not found!");
            CheckUserInChat(chat, userId);
            _privateChatRepository.RemoveChat(entityId);
        }

        public void EditMessage(Guid userId, Guid chatId, Guid messageId, string newText)
        {
            var chat = _privateChatRepository.GetChat(chatId) ?? 
                       throw new ApplicationException("Chat not found!");
            CheckUserInChat(chat, userId);
            var message = _privateChatRepository.GetMessage(messageId) ?? 
                          throw new ApplicationException("The message not found!");
            if (message.CreatedBy != userId)
                throw new ApplicationException("Not enough rights!");
            message.Text = newText;
            _privateChatRepository.EditMessage(message);
        }

        public void RemoveMessage(Guid userId, Guid chatId, Guid messageId)
        {
            var chat = _privateChatRepository.GetChat(chatId) ?? 
                       throw new ApplicationException("Chat not found!");
            CheckUserInChat(chat, userId);
            _privateChatRepository.RemoveMessage(chatId, messageId);
        }

        public Message GetMessage(Guid userId, Guid chatId, Guid messageId)
        {
            var chat = _privateChatRepository.GetChat(chatId) ?? 
                       throw new ApplicationException("Chat not found!");
            CheckUserInChat(chat, userId);
            return _privateChatRepository.GetMessage(messageId);
        }

        private void CheckUserInChat(PrivateChat chat, Guid userId)
        {
            var users = chat.Users ?? 
                        throw new ApplicationException("There are not users in chat!");
            if (!users.Contains(userId))
                throw new ApplicationException("This user is not in private chat!");
        }
    }
}