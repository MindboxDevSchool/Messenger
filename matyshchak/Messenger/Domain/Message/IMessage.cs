using System;
using Domain.Chats;

namespace Domain.Message
{
    public interface IMessage : IEntity
    {
        public Guid AuthorId { get; }
        public IChat Chat { get; }
        public DateTime TimePosted { get; }
        public MessageContent Content { get; }

        public IMessage Edit(MessageContent newContent);
    }

    public class MessageContent
    {
        public MessageContent(string content)
        {
            Content = content;
        }

        public string Content { get; }
    }
}