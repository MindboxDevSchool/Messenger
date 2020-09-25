using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IChat
    {
        Guid Id { get; }

        List<IMessage> MessageList { get; }
        List<IUser> UserList { get; }
        bool IsInUserList(IUser user);
        bool IsInOwnerList(IUser user);
        bool IsInMessageList(IMessage message);
        bool IsSenderOfMessage(IUser user, IMessage message);

        void AddMessage(IMessage message);
        void EditMessage(IUser userActing, IMessage message, string messageText);
        void DeleteMessage(IUser userActing, IMessage message);

        void AddUser(IUser userActing);
        void DeleteUser(IUser userActing, IUser userToDelete);
    }
}