using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class PrivateChat : Chat
    {
        public PrivateChat(Guid id, List<IUser> ownerList, List<IUser> userList, List<IMessage> messageList) : base(id, ownerList, userList, messageList)
        {
        }
        
        public override void DeleteMessage(IUser userActing, IMessage message)
        {
            if (!IsInUserList(userActing)) throw new NotFoundException("This user not found in this chat!");
            if (!IsInMessageList(message)) throw new NotFoundException("This message not found in this chat!");
            if (!IsSenderOfMessage(userActing, message)) throw new NoPermissionException("This user can't delete this message!");
            MessageList.Remove(message);
        }

        public override void AddUser(IUser userToAdd)
        {
            throw new NoPermissionException("This user can't join private chat!");
        }

        public override void DeleteUser(IUser userActing, IUser userToDelete)
        {
            if (!IsInUserList(userActing)) throw new NotFoundException("This user not found in this chat!");
            if (!(userActing.Id == userToDelete.Id)) throw new NoPermissionException("This user can't delete another user!");
            UserList.Remove(userToDelete);
        }
    }
}