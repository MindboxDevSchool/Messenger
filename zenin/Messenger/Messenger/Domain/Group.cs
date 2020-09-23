using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Group : Chat
    {
        private List<User> _groupSuperUsers = new List<User>();

        public Group(User user) : base(user)
        {
            _groupSuperUsers.Add(user);
        }
        
        public void AddNewMember(User user)
        {
            _memberRepository.CreateUser(user);
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