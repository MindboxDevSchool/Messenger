using System;

namespace Messenger
{
    public interface IUserService
    {
        Guid CreateNewUser(string userName);
    }
}