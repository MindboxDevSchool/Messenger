﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Messenger.Domain
{
    public class GroupChannel:Group,IGroup
    {
        private readonly IUser _author;
        public GroupChannel(IUser creator, 
                            IMessageInGroupRepository messages,
                            IUsersRepository users,Guid id) : base(creator, messages, users,id)
        {
            _author = creator;
        }
        
        public void AddNewMember(User user)
        {
            _memberRepository.CreateUser(user);
        }

        protected override bool CanUserSendMessage(IUser user)
        {
            return user.Id == _author.Id;
        }

        protected override bool CanUserEditMessage(IUser user, IMessage message)
        {
            return user.Id == _author.Id;
        }

        protected override bool CanUserDeleteMessage(IUser user, IMessage message)
        {
            return user.Id == _author.Id;
        }
    }
}