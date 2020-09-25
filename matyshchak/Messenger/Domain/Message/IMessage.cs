using System;
using Domain.Chat;
using Domain.User;

namespace Domain
{
    public interface IMessage
    {
        public Guid Id { get; }
        public Guid ChatId { get; }
        public Guid AuthorId { get; }
        public DateTime TimePosted { get; }
        public string Content { get; }
    }
}