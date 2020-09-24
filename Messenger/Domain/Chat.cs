using System;
using Messenger.Infrastructure;

namespace Messenger.Domain
{
    public abstract class Chat : IChat
    {
        public Guid ChatId { get; }
        public User ChatCreator { get; }
        public DateTime CreatedDate { get; }
        public string ChatName { get; protected set; }
        
        protected readonly IMessageRepository _messageRepository;
        protected readonly IUserRepository _userRepository;

        public Chat(User user)
        {
            CreatedDate = DateTime.Now;
            ChatCreator = user;
            _messageRepository = new MessageRepository();
            _userRepository = new UserRepository();
            _userRepository.CreateUser(user);
        }

        protected abstract bool MessageSendingPermission(User user);
        protected abstract bool MessageEditingPermission(User user);
        protected abstract bool MessageDeletingPermission(User user);

        public Guid SendMessage(User user, string messageText)
        {
            if ((MessageSendingPermission(user))
                && (_userRepository.GetUser(user.UserId) != null))
            {
                Message newMessage = new Message(user, messageText);
                _messageRepository.CreateMessage(newMessage);
                return newMessage.MessageId;
            }
            else
            {
                return default(Guid);
            }
        }

        public Message GetMessage(Guid messageId)
        {
            return _messageRepository.GetMessage(messageId);
        }

        public void EditMessage(User user, Message message, string newMessageText)
        {
            if ((MessageEditingPermission(user))
                && (_userRepository.GetUser(user.UserId) != null))
            {
                message.MessageText = newMessageText;
                _messageRepository.UpdateEditedMessage(message.MessageId, message);
            }
        }

        public void DeleteMessage(User user, Message message)
        {
            if ((MessageDeletingPermission(user))
                && (_userRepository.GetUser(user.UserId) != null))
            {
                _messageRepository.DeleteMessage(message.MessageId);
            }
        }
    }
}