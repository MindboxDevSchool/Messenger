using System;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public Guid UserId { get; }
        public String Login { get; }

        public String Password { get; }

        public User(String login, String password)
        {
            UserId = Guid.NewGuid();
            Login = login;
            Password = password;
        }
    }
}