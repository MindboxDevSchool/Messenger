using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        void AddChatTo(Guid userId, Guid chatId, RoleType roleType);
        void ChangeChatRoleTo(Guid userId, Guid chatId, RoleType roleType);
        void DeleteChatTo(IEnumerable<IUser> chatUsers, Guid chatId);
        void DeleteChatTo(IUser user, Guid chatId);
    }
}