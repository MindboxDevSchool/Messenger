using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public abstract class Chat : IChat
    {
        public Guid Id { get; }
        protected List<IUser> OwnerList { get; }
        public List<IUser> UserList { get; }
        public List<IMessage> MessageList { get; }

        public Chat(Guid id, List<IUser> ownerList, List<IUser> userList, List<IMessage> messageList)
        {
            OwnerList = ownerList ?? throw new ArgumentNullException(nameof(ownerList));
            UserList = userList ?? throw new ArgumentNullException(nameof(userList));
            MessageList = messageList ?? throw new ArgumentNullException(nameof(messageList));
            Id = id;
        }

        public bool IsInUserList(IUser user)
        {
            return UserList.Contains(user) || OwnerList.Contains(user);
        }

        public bool IsInOwnerList(IUser user)
        {
            return OwnerList.Contains(user);
        }

        public bool IsInMessageList(IMessage message)
        {
            return MessageList.Contains(message);
        }

        public bool IsSenderOfMessage(IUser user, IMessage message)
        {
            return message.Sender.Id == user.Id;
        }

        public virtual void AddMessage(IMessage message)
        {
            if (!IsInUserList(message.Sender)) throw new NotFoundException("This user not found in this chat!");
            MessageList.Add(message);
        }

        public void EditMessage(IUser userActing, IMessage message, string messageText)
        {
            if (!IsInUserList(userActing)) throw new NotFoundException("This user not found in this chat!");
            if (!IsInMessageList(message)) throw new NotFoundException("This message not found in this chat!");
            if (!IsSenderOfMessage(userActing, message))
                throw new NoPermissionException("This user can't edit this message!");
            message.Text = messageText;
        }

        public virtual void DeleteMessage(IUser userActing, IMessage message)
        {
            if (!IsInUserList(userActing)) throw new NotFoundException("This user not found in this chat!");
            if (!IsInMessageList(message)) throw new NotFoundException("This message not found in this chat!");
            if (IsSenderOfMessage(userActing, message))
            {
                MessageList.Remove(message);
                return;
            }

            if (!IsInOwnerList(userActing)) throw new NoPermissionException("This user can't delete this message!");
            MessageList.Remove(message);
        }

        public virtual void AddUser(IUser userActing)
        {
            if (!IsInUserList(userActing)) UserList.Add(userActing);
        }

        public virtual void DeleteUser(IUser userActing, IUser userToDelete)
        {
            if (!IsInUserList(userActing)) throw new NotFoundException("This user not found in this chat!");
            if (!(IsInOwnerList(userActing) || userActing.Id == userToDelete.Id))
                throw new NoPermissionException("This user can't delete this user!");
            UserList.Remove(userToDelete);
            if (IsInOwnerList(userToDelete)) OwnerList.Remove(userToDelete);
        }
    }
}