using System;
using System.Collections.Generic;
using Domain.Chat;

namespace Domain.User
{
    public interface IUser
    {
        public Guid Id { get; }
        public UserName Name { get; }
        public PhoneNumber PhoneNumber { get; }
        public IReadOnlyList<Guid> ChatsIds { get; }
    }
}