using System;
using Messenger.Infrastructure;

namespace Messenger.Domain
{
    public abstract class Chat : IChat
    {
        public Guid ChatId { get; }
        public IUser ChatCreator { get; }
        public DateTime CreatedDate { get; }
        public string ChatName { get; }
        
        protected readonly IMessageRepository _messageRepository;
        protected readonly IUserRepository _userRepository;

        public Chat(IUser chatCreator, String chatName)
        {
            CreatedDate = DateTime.Now;
            ChatCreator = chatCreator;
            ChatId = Guid.NewGuid();
            ChatName = chatName;
            _messageRepository = new MessageRepository();
            _userRepository = new UserRepository();
            _userRepository.AddUser(chatCreator);
        }

        protected abstract bool MessageSendingPermission(IUser user);
        protected abstract bool MessageEditingPermission(IUser user, IMessage message);
        protected abstract bool MessageDeletingPermission(IUser user);

        public Guid SendMessage(IUser user, string messageText)
        {
            if ((MessageSendingPermission(user))
                && (_userRepository.GetUser(user.UserId) != null))
            {
                
                IMessage newMessage = _messageRepository.CreateMessage(user, messageText);
                return newMessage.MessageId;
            }
            throw new UnauthorizedAccessException(
                "This user is not able to send the message to the chat!"
                );
        }

        public IMessage GetMessage(Guid messageId)
        {
            return _messageRepository.GetMessage(messageId);
        }

        public void EditMessage(IUser user, IMessage message, string newMessageText)
        {
            if ((MessageEditingPermission(user, message))
                && (_userRepository.GetUser(user.UserId) != null))
            {
                message.MessageText = newMessageText;
                _messageRepository.UpdateEditedMessage(message.MessageId, message);
            }
            throw new UnauthorizedAccessException(
                "This user is not able to edit the message in the chat!"
                );
        }

        public void DeleteMessage(IUser user, IMessage message)
        {
            if ((MessageDeletingPermission(user))
                && (_userRepository.GetUser(user.UserId) != null))
            {
                _messageRepository.DeleteMessage(message.MessageId);
            }
            throw new UnauthorizedAccessException(
                "This user is not able to delete the message from the chat!"
                );
        }
    }
}