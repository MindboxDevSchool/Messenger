using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Chanel : Chat
    {
        public Chanel(Guid id, List<IUser> owner, List<IUser> userList, List<IMessage> messageList) : base(id, owner,
            userList, messageList)
        {
        }

        public override void AddMessage(IMessage message)
        {
            if (!IsInUserList(message.Sender)) throw new NotFoundException("This user not found in this chat!");
            if (!IsInOwnerList(message.Sender)) throw new NoPermissionException("This user can't send this message!");
            MessageList.Add(message);
        }
    }
}