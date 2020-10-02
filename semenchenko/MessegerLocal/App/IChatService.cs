using System;
using System.Collections.Generic;
using Messeger.Domain.Chat;
using Messeger.Domain;

namespace Messeger.App
{
    public interface IChatService
    {
        void AddUserToChat(Guid UserId, Guid ChatId);

        void ChangeUserRole(Guid UserId, Guid ChatId, Guid GivenByUserId);

        void RemoveUserFromChat(Guid UserId, Guid ChatId);

        IEnumerable<IChat> GetUsersChats(Guid UseId);
    }
}