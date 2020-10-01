using System;
using Domain.Chats;
using Domain.User;

namespace Domain.Message
{
    public interface IMessage : IEntity
    {
        public IUser Author { get; }
        public IChat Chat { get; }
        public MessageContent Content { get; }
        public DateTime TimePosted { get; }
        public IMessage Edit(MessageContent newContent);
    }
}