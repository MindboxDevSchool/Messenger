using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUserRepository
    {
        IUser GetBy(Guid userId);
        void Update(IUser user);
        void Update(IEnumerable<IUser> users);
        void Save(IUser user);
    }
}