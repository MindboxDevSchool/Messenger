using System;
using System.Collections.Generic;

namespace Messenger
{
    public abstract class Chat : IChat
    {
        public Guid Id { get; }
        public string Name { get; }
        public User CreatedBy { get; protected set; }
        public DateTime CreatedAt { get; protected set;}
        
        protected List<User> _members;
        private List<Message> _messages;

        public Chat(User user)
        {
            CreatedAt = DateTime.Now;
            CreatedBy = user;
            _members.Add(user);
        }

        protected abstract bool CanUserSendMessage(User user);
        protected abstract bool CanUserEditMessage(User user, Message message);
        protected abstract bool CanUserDeleteMessage(User user, Message message);
        
        public void SendMessage(User user, string text)
        {
            if(CanUserSendMessage(user) && _members.Contains(user))
                _messages.Add(new Message(user, text));
        }

        public void EditMessage(User user, Message message, string newText)
        {
            if (CanUserEditMessage(user, message) && _members.Contains(user))
                message.Text = newText;
        }
        
        public void DeleteMessage(User user, Message message)
        {
            if (CanUserDeleteMessage(user, message) && _members.Contains(user))
                _messages.Remove(message);
        }
    }
}