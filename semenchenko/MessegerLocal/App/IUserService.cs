using System;
using Messeger.Domain;

namespace Messeger.App
{
    public interface IUserService
    {
        Guid RegisterUser();

        bool LoginUser(string username, string password);

        User SearchUser();
    }
}