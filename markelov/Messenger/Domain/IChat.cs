using System;
using System.Collections;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IChat
    {
        IEnumerable<IUser> Admins { get; set; }
        IEnumerable<IUser> Users { get; set; }
        IEnumerable<IMessage> Messages { get; set; }
        ChatTypes ChatType { get; }
        Guid Id { get; }
        bool CanUserSendMessages(IUser user);
        bool CanUserUpdateMessages(IUser user, IMessage message);
        bool CanUserDeleteMessages(IUser user, IMessage message);
        bool CanUserMakeAdmins(IUser user);
        void Notify();
    }
}