using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class GroupChat : Chat
    {
        public GroupChat(Guid id, List<IUser> owner, List<IUser> userList, List<IMessage> messageList) : base(id, owner,
            userList, messageList)
        {
        }
    }
}