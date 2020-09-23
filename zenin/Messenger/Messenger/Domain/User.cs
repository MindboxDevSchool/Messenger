using System;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public string Name { get; }
        public Guid Id { get; }

        public User(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
    }
}