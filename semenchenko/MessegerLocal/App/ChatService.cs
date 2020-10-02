using System;
using System.Collections.Generic;
using Messeger.Domain.Chat;

namespace Messeger.App
{
    public class ChatService : IChatService
    {
        public void AddUserToChat(Guid UserId, Guid ChatId)
        {
            throw new NotImplementedException();
        }

        public void ChangeUserRole(Guid UserId, Guid ChatId, Guid GivenByUserId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromChat(Guid UserId, Guid ChatId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IChat> GetUsersChats(Guid UseId)
        {
            throw new NotImplementedException();
        }
    }
}