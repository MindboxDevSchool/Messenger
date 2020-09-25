using System;
using System.Collections.Generic;
using Domain.Chat;

namespace Domain.User
{
    public class User : IUser
    {
        public User(Guid id, UserName name, PhoneNumber phoneNumber, IReadOnlyList<Guid> chatsIds)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            ChatsIds = chatsIds;
        }

        public Guid Id { get; }
        public UserName Name { get; }
        public PhoneNumber PhoneNumber { get; }
        public IReadOnlyList<Guid> ChatsIds { get; }
    }
}