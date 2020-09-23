using System;

namespace Messenger
{
    public class PrivateChat : Chat
    {
        public PrivateChat(User user1, User user2) : base(user1)
        {
            _members.Add(user2);
        }
        
        protected override bool CanUserSendMessage(User user)
        {
            return true;
        }

        protected override bool CanUserEditMessage(User user, Message message)
        {
            return message.CreatedBy == user.Id;
        }

        protected override bool CanUserDeleteMessage(User user, Message message)
        {
            return message.CreatedBy == user.Id;
        }
    }
}