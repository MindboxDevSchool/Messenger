using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        IUserRepository UserRepository { get; }

        Guid RegisterUser(string username);
    }
}