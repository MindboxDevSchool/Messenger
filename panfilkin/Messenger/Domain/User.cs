using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public Guid Id { get; }
        public string Username { get; }

        public User(Guid id, string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Id = id;
        }
    }
}