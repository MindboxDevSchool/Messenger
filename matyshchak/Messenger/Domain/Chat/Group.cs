using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Chat
{
    public class Group : IChat
    {
        public Guid Id { get; }
        public IReadOnlyList<IMessage> Messages { get; }
        public IReadOnlyList<IUser> Members { get; }
    }
}