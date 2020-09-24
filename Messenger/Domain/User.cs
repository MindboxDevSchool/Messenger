using System;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public Guid UserId { get; }
        public String Login { get; }

        public User(String login)
        {
            UserId = Guid.NewGuid();
            Login = login;
        }
    }
}