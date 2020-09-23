using System;
using Domain.Chat;

namespace Domain.User
{
    public interface IMessage
    {
        public Guid Id { get; }
        public IUser Author { get; }
        public IChat Chat { get; }
        public DateTime DateTime { get; }
        public string Content { get; }
    }
}