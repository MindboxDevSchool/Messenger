using System;
using System.Collections;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserRepository
    {
        IUser GetBy(Guid userId);
        void Update(IUser user);
        void Update(IEnumerable<IUser> users);
        void Save(IUser user);
    }
}