using System;
using System.Collections.Generic;
using Domain.Chat;

namespace Domain.User
{
    public interface IUser
    {
        public Guid Id { get; }
        public Name Name { get; }
        public IReadOnlyList<IChat> Chats { get; }
    }
}