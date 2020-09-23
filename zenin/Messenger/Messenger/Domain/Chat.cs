using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Messenger.Infrastructure;

namespace Messenger.Domain
{
    public abstract class Chat : IChat
    {
        public Guid Id { get; }
        public string Name { get; }
        public User CreatedBy { get; protected set; }
        public DateTime CreatedAt { get; protected set;}
        protected readonly IMessageRepository _messageRepository;
        protected readonly IUserRepository _memberRepository;

        public Chat(User user)
        {
            CreatedAt = DateTime.Now;
            CreatedBy = user;
            _messageRepository = new MessageRepository(); 
            _memberRepository = new UserRepository();
            _memberRepository.CreateUser(user);
        }

        protected abstract bool CanUserSendMessage(User user);
        protected abstract bool CanUserEditMessage(User user, Message message);
        protected abstract bool CanUserDeleteMessage(User user, Message message);
        
        public Guid SendMessage(User user, string text)
        {
            Message newMessage = new Message(user, text);
            if (CanUserSendMessage(user) && _memberRepository.GetUser(user.Id) != null)
                _messageRepository.CreateMessage(newMessage);
            return newMessage.Id;
        }

        public Message GetMessage(Guid messageId)
        {
            return _messageRepository.GetMessage(messageId);
        }

        public void EditMessage(User user, Message message, string newText)
        {
            if (CanUserEditMessage(user, message) && _memberRepository.GetUser(user.Id) != null)
            {
                message.Text = newText;
                _messageRepository.UpdateMessage(message.Id, message);
            }
        }
        
        public void DeleteMessage(User user, Message message)
        {
            if (CanUserDeleteMessage(user, message) && _memberRepository.GetUser(user.Id) != null)
                _messageRepository.DeleteMessage(message.Id);
        }
    }
}