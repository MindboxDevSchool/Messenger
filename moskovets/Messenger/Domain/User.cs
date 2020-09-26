using System;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public User(String id, string login)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Login = login ?? throw new ArgumentNullException(nameof(login));
        }

        public String Id { get; }
        public string Login { get; set; }
    }
}