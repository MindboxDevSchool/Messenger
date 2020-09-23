using System;
using System.Collections.Generic;

namespace Messenger
{
    public class Group : Chat
    {
        private List<User> _groupSuperUsers;

        public Group(User user) : base(user)
        {
            _groupSuperUsers.Add(user);
        }
        
        public void AddNewMember(User user)
        {
            _members.Add(user);
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
            return _groupSuperUsers.Contains(user);
        }
    }
}