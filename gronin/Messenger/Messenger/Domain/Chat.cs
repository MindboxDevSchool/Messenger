﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Messenger.Domain
{
    public class Chat : Group
    {
        private List<IUser> _groupAdmins = new List<IUser>();

        public Chat(IUser creator,
                     IMessageInGroupRepository messages,
                     IUsersRepository users,Guid id) 
                     : base(creator, messages, users,id)
        {
            _groupAdmins.Add(creator);
        }
        
        public void AddNewMember(User user)
        {
            _memberRepository.CreateUser(user);
        }
        
        public void AddAdmin(User user)
        {
            _groupAdmins.Add(user);
        }
        protected override bool CanUserSendMessage(IUser user)
        {
            return true;
        }

        protected override bool CanUserEditMessage(IUser user, IMessage message)
        {
            return message.SenderId == user.Id;
        }

        protected override bool CanUserDeleteMessage(IUser user, IMessage message)
        {
            return _groupAdmins.Contains(user);
        }
    }
}