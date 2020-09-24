using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUsersRepository
    {
        public void CreateUser(IUser user);
        public IUser GetUser(Guid memberId);
        public void DeleteUser(Guid memberId);
    }
}